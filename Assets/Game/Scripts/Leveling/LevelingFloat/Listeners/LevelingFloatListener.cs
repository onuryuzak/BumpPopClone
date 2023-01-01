using UnityEngine;
using UnityEngine.Events;


public class LevelingFloatListener : LevelingVariableListener<float>
{
    #region PUBLIC EVENTS

    public UnityEvent<int> OnChangedValueRoundToInt;

    #endregion

    #region PROTECTED OVERRIDEN METHODS

    protected override void TriggerLevelingChanged(int leveling)
    {
        base.TriggerLevelingChanged(leveling);
        OnChangedValueRoundToInt?.Invoke(Mathf.RoundToInt(levelingVariable.Value));
    }

    #endregion
}