using System;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Leveling/Calculators/LinearWithPercentLevelingFloatCalculator",
    fileName = "LinearWithPercentLevelingFloatCalculator")]
public class LinearWithTotalPercentLevelingFloatCalculator : BaseLevelingFloatCalculator
{
    [SerializeField] private float startValue;
    [SerializeField] private float flatModifierByLocalLevel;

    [Header("Multiplier")] [SerializeField] [EnumToggleButtons]
    private LevelingFloatCalculatorMultiplierType multiplierType;

    [ShowIf("multiplierType", LevelingFloatCalculatorMultiplierType.Atom)] [SerializeField]
    private FloatReference percentMultiplierReference = new FloatReference(1);

    [ShowIf("multiplierType", LevelingFloatCalculatorMultiplierType.LevelingFloat)] [SerializeField]
    private LevelingFloat percentMultiplierLeveling;

    [ShowIf("multiplierType", LevelingFloatCalculatorMultiplierType.LevelingCalculator)] [SerializeField]
    private BaseLevelingFloatCalculator percentMultiplierCalculator;

    protected override float CalculateInternal(int level)
    {
        var increaseValue = flatModifierByLocalLevel * (level - 1);

        var value = startValue + increaseValue;

        var percentMultiplier = GetPercentMultiplier(level);
        value *= percentMultiplier;

        return value;
    }

    private float GetPercentMultiplier(int level) =>
        multiplierType switch
        {
            LevelingFloatCalculatorMultiplierType.Atom => percentMultiplierReference,
            LevelingFloatCalculatorMultiplierType.LevelingFloat => percentMultiplierLeveling.Value,
            LevelingFloatCalculatorMultiplierType.LevelingCalculator => percentMultiplierCalculator.Calculate(level),
            _ => 1
        };
}