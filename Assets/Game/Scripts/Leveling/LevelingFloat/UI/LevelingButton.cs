using Sirenix.OdinInspector;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelingButton : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [Header("Static Info")]
    [SerializeField] private Image iconImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TMP_Text titleTmp;

    [Header("Dynamic Info")]
    [SerializeField] private TMP_Text levelTmp;
    [SerializeField] private TMP_Text costTmp;
    [SerializeField] private IntVariableInstancer costVariable;

    [Header("Events")]
    [SerializeField] private UnityEvent onMaxLevelReached;

    [Header("State")]
    [SerializeField] [ReadOnly] private LevelingButtonData levelingButtonData;

    #endregion

    #region PRIVATE PROPERTIES

    #endregion

    #region PUBLIC PROPERTIES

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        UpdateDynamicInfo();
        RegisterToLeveling();
    }

    private void OnDisable()
    {
        UnregisterFromLeveling();
    }

    #endregion

    #region PRIVATE METHODS

    private void UpdateDynamicInfo()
    {
        if (levelingButtonData == null) 
            return;

        levelTmp.SetText($"Lv {levelingButtonData.MainLevelingFloat.Level}");
        costTmp.SetText($"{Mathf.RoundToInt(levelingButtonData.CostLeveling.Value)}");
        costVariable.Value = Mathf.RoundToInt(levelingButtonData.CostLeveling.Value);

        if (!levelingButtonData.MainLevelingFloat.Leveling.MaxLevelReached)
            return;

        onMaxLevelReached?.Invoke();
    }
    
    private void RegisterToLeveling()
    {
        if (levelingButtonData == null)
            return;
        levelingButtonData.MainLevelingFloat.Leveling.OnChanged.AddListener(OnLevelChanged);
    }

    private void UnregisterFromLeveling()
    {
        if (levelingButtonData == null)
            return;
        levelingButtonData.MainLevelingFloat.Leveling.OnChanged.RemoveListener(OnLevelChanged);
    }

    private void OnLevelChanged(int level) =>
        UpdateDynamicInfo();

    #endregion

    #region PUBLIC METHODS

    public void SetData(LevelingButtonData data)
    {
        UnregisterFromLeveling();
        levelingButtonData = data;
        RegisterToLeveling();

        iconImage.sprite = levelingButtonData.Icon;
        if (levelingButtonData.Background != null)
            backgroundImage.sprite = levelingButtonData.Background;
        titleTmp.SetText(levelingButtonData.Title);

        UpdateDynamicInfo();
    }

    public void IncreaseLevel() =>
        levelingButtonData.MainLevelingFloat.IncreaseLevel();

    #endregion
}