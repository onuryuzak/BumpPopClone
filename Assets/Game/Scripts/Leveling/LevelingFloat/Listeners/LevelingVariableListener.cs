using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;


public abstract class LevelingVariableListener<T> : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [SerializeField] protected LevelingVariable<T> levelingVariable;
    [SerializeField] [EnumToggleButtons] private TriggerEventTime triggerEventTime = TriggerEventTime.OnAwake;

    #endregion

    #region PRIVATE PROPERTIES

    private bool TriggerEventsOnAwake => triggerEventTime == TriggerEventTime.OnAwake;
    private bool TriggerEventsOnEnable => triggerEventTime == TriggerEventTime.OnEnable;
    private bool TriggerEventsOnStart => triggerEventTime == TriggerEventTime.OnStart;

    #endregion

    #region PUBLIC EVENTS

    public UnityEvent<T> OnChangedValue;
    public UnityEvent<int> OnChangedLevel;

    #endregion

    #region UNITY METHODS

    private void Awake() => TriggerEventsIfConditionMet(TriggerEventsOnAwake);

    private void Start() => TriggerEventsIfConditionMet(TriggerEventsOnStart);

    private void OnEnable()
    {
        TriggerEventsIfConditionMet(TriggerEventsOnEnable);
        SubscribeToLeveling();
    }

    private void OnDisable()
    {
        UnsubscribeFromLeveling();
    }

    #endregion

    #region PRIVATE METHODS

    private void SubscribeToLeveling()
    {
        levelingVariable.Leveling.OnChanged.AddListener(TriggerLevelingChanged);
    }

    private void UnsubscribeFromLeveling()
    {
        if (levelingVariable == null) return;
        levelingVariable.Leveling.OnChanged.RemoveListener(TriggerLevelingChanged);
    }

    private void TriggerEventsIfConditionMet(bool trigger)
    {
        if (levelingVariable == null) return;
        if (trigger)
            TriggerLevelingChanged(levelingVariable.Leveling.Value);
    }

    protected virtual void TriggerLevelingChanged(int leveling)
    {
        OnChangedLevel?.Invoke(leveling);
        OnChangedValue?.Invoke(levelingVariable.Value);
    }

    #endregion

    #region PUBLIC METHODS

    public void UpdateData(LevelingVariable<T> newLevelingVariable, bool triggerEvent = true)
    {
        UnsubscribeFromLeveling();
        levelingVariable = newLevelingVariable;
        SubscribeToLeveling();
        if (triggerEvent)
            TriggerLevelingChanged(levelingVariable.Leveling.Value);
    }

    #endregion

    private enum TriggerEventTime
    {
        None,
        OnAwake,
        OnEnable,
        OnStart,
    }
}