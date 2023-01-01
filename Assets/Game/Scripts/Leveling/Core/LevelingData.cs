using System;
using PersistentSO;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;


public enum LevelingDataValueType
{
    Atom,
    PersistentSO,
}

[CreateAssetMenu(menuName = "ScriptableObjects/Leveling/LevelingData", fileName = "LevelingData")]
public class LevelingData : ScriptableObject
{
    #region INSPECTOR FIELDS

    [SerializeField] [ToggleLeft] private bool hasMaxLevel;

    [SerializeField] [ShowIf("hasMaxLevel")]
    private int maxLevel;

    [SerializeField] [EnumToggleButtons] private LevelingDataValueType dataValueType;

    [SerializeField] [LabelText("Level")] [ShowIf("dataValueType", LevelingDataValueType.Atom)]
    private IntReference atomLevel;

    [SerializeField] [LabelText("Level")] [ShowIf("dataValueType", LevelingDataValueType.PersistentSO)]
    private PersistentIntVariable persistentLevel;

    #endregion

    #region PUBLIC EVENTS

    [FoldoutGroup("Events")] public UnityEvent<int> OnChanged;
    [FoldoutGroup("Events")] public UnityEvent OnIncreased;
    [FoldoutGroup("Events")] public UnityEvent OnDecreased;

    #endregion

    #region PUBLIC PROPERTIES

    public int Value => GetLevel();
    public bool HasMaxLevel => hasMaxLevel;
    public int MaxLevel => maxLevel;
    public bool MaxLevelReached => HasMaxLevel && GetLevel() >= maxLevel;

    #endregion

    #region PUBLIC METHODS

    public void SetLevel(int level)
    {
        var previousLevel = GetLevel();

        level = Mathf.Clamp(level, 0, hasMaxLevel ? maxLevel : int.MaxValue);

        if (previousLevel == level)
            return;

        switch (dataValueType)
        {
            case LevelingDataValueType.Atom:
                atomLevel.Value = level;
                break;
            case LevelingDataValueType.PersistentSO:
                persistentLevel.Value = level;
                break;
            default:
                throw new Exception($"Unknown LevelingDataValueType {dataValueType}");
        }

        OnChanged?.Invoke(level);
    }

    public void IncreaseLevel()
    {
        SetLevel(Value + 1);
        OnIncreased?.Invoke();
    }

    public void DecreaseLevel()
    {
        SetLevel(Value - 1);
        OnDecreased?.Invoke();
    }

    #endregion

    #region PRIVATE METHODS

    private int GetLevel() => dataValueType switch
    {
        LevelingDataValueType.Atom => atomLevel,
        LevelingDataValueType.PersistentSO => persistentLevel,
        _ => 0,
    };

    #endregion
}