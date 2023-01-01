using UnityEngine;


public abstract class BaseLevelingFloatCalculator : LevelingVariableCalculator<float>
{
    [SerializeField] private Vector2 clampMinMax = new Vector2(float.MinValue, float.MaxValue);

    public override float Calculate(int level)
    {
        var result = CalculateInternal(level);
        return Mathf.Clamp(result, clampMinMax.x, clampMinMax.y);
    }

    protected abstract float CalculateInternal(int level);
}