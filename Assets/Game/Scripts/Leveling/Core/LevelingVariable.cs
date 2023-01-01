using UnityEngine;


public abstract class LevelingVariable<T> : ScriptableObject
{
    #region INSPECTOR FIELDS

    [Header("References")] [SerializeField]
    protected LevelingData leveling;

    [SerializeField] protected LevelingVariableCalculator<T> calculator;

    #endregion

    #region PUBLIC PROPERTIES

    public LevelingData Leveling => leveling;
    public LevelingVariableCalculator<T> Calculator => calculator;
    public int Level => leveling.Value;
    public T Value => Calculator.Calculate(Level);

    #endregion

    #region PUBLIC METHODS

    public void SetLevel(int level) => leveling.SetLevel(level);
    public void IncreaseLevel() => leveling.IncreaseLevel();
    public void DecreaseLevel() => leveling.DecreaseLevel();

    public virtual T GetAccumulatedValueForLevel(int level)
    {
        Debug.Log("Not implemented.");
        return default;
    }

    #endregion
}