using UnityAtoms.BaseAtoms;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Leveling/Calculators/LinearLevelingFloatCalculator",
    fileName = "LinearLevelingFloatCalculator")]
public class LinearLevelingFloatCalculator : BaseLevelingFloatCalculator
{
    [SerializeField] private float startValue;
    [SerializeField] private float increaseValue;
    [SerializeField] private FloatReference increaseValueLevelMultiplier = new FloatReference(-1);

    protected override float CalculateInternal(int level)
    {
        var value = startValue + (level - 1) * increaseValue * increaseValueLevelMultiplier;
        return value;
    }
}