using UnityEngine;
using UnityEngine.Events;


public class LevelingDataListener : MonoBehaviour
{
    #region INSPECTOR FIELDS

    public LevelingData levelingData;
    [SerializeField] private bool triggerEventsOnAwake = true;
    [SerializeField] private bool triggerEventsOnStart;
    [SerializeField] private bool triggerEventsOnEnable;

    #endregion

    #region PUBLIC EVENTS

    public UnityEvent<int> OnChanged;

    #endregion

    #region UNITY METHODS

    private void Awake() => TriggerEventsIfConditionMet(triggerEventsOnAwake);

    private void Start() => TriggerEventsIfConditionMet(triggerEventsOnStart);

    private void OnEnable()
    {
        TriggerEventsIfConditionMet(triggerEventsOnEnable);
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
        if (levelingData == null) return;
        levelingData.OnChanged.AddListener(TriggerLevelingChanged);
    }

    private void UnsubscribeFromLeveling()
    {
        if (levelingData == null) return;
        levelingData.OnChanged.RemoveListener(TriggerLevelingChanged);
    }

    private void TriggerEventsIfConditionMet(bool trigger)
    {
        if (levelingData == null) return;
        if (trigger)
            TriggerLevelingChanged(levelingData.Value);
    }

    private void TriggerLevelingChanged(int leveling)
    {
        OnChanged?.Invoke(leveling);
    }

    #endregion

    #region PUBLIC METHODS

    public void UpdateData(LevelingData levelingData, bool triggerEvent = true)
    {
        UnsubscribeFromLeveling();
        this.levelingData = levelingData;
        SubscribeToLeveling();
        if (triggerEvent)
            TriggerLevelingChanged(levelingData.Value);
    }

    #endregion
}