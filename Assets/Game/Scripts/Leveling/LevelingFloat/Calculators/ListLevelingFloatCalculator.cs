using System.Collections.Generic;
using MyBox;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Leveling/Calculators/ListLevelingFloatCalculator",
    fileName = "ListLevelingFloatCalculator")]
public class ListLevelingFloatCalculator : BaseLevelingFloatCalculator
{
    [Header("Settings")] [SerializeField] private bool startAtLevelOne = true;
    [Space] [SerializeField] private List<float> values;

    [Header("Multiplier")] [SerializeField] [EnumToggleButtons]
    private LevelingFloatCalculatorMultiplierType multiplierType;

    [ShowIf("multiplierType", LevelingFloatCalculatorMultiplierType.Atom)] [SerializeField]
    private FloatReference percentMultiplierReference;

    [ShowIf("multiplierType", LevelingFloatCalculatorMultiplierType.LevelingFloat)] [SerializeField]
    private LevelingFloat percentMultiplierLeveling;

    [ShowIf("multiplierType", LevelingFloatCalculatorMultiplierType.LevelingCalculator)] [SerializeField]
    private BaseLevelingFloatCalculator percentMultiplierCalculator;

    protected override float CalculateInternal(int level)
    {
        if (values.IsNullOrEmpty())
            return 0f;

        var levelToUse = startAtLevelOne ? level - 1 : level;
        var index = Mathf.Min(levelToUse, values.Count - 1);

        return values[index] * GetPercentMultiplier(level);
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