using UnityEngine;


public abstract class LevelingVariableCalculator<T> : ScriptableObject
{
    public abstract T Calculate(int level);
}