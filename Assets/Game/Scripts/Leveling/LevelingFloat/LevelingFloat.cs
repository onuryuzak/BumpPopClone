using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Leveling/LevelingFloat", fileName = "LevelingFloat")]
public class LevelingFloat : LevelingVariable<float>
{
    #region PUBLIC METHODS

    public override float GetAccumulatedValueForLevel(int level)
    {
        var value = 0f;

        var count = Leveling.HasMaxLevel ? Mathf.Min(level, Leveling.MaxLevel) : level;
        for (var i = 1; i < count; i++)
            value += calculator.Calculate(i);
        return value;
    }

    #endregion
}