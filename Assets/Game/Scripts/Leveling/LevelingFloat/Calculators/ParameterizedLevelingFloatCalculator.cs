using System;
using System.Collections.Generic;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Leveling/Calculators/ParameterizedLevelingFloatCalculator",
    fileName = "ParameterizedLevelingFloatCalculator")]
public class ParameterizedLevelingFloatCalculator : BaseLevelingFloatCalculator
{
#if UNITY_EDITOR
    [InfoBox("@GetInfo()")] [SerializeField]
    private bool getSumInfo;
#endif

    [SerializeField] private float startValue;
    [SerializeField] private bool repeatLastModifier = true;

    [ListDrawerSettings(CustomAddFunction = "AddNewValueModifier")] [SerializeField]
    private List<ValueModifierData> valueModifiers;

    protected override float CalculateInternal(int level)
    {
        var value = startValue;

        for (var i = 1; i < level; i++)
        {
            var valueMod = GetValueModifierForLevel(i);

            var modValue = valueMod.GetValue(i);
            switch (valueMod.calculateType)
            {
                case CalculateType.Multiplier:
                    value *= modValue;
                    break;
                case CalculateType.Flat:
                default:
                    value += modValue;
                    break;
            }
        }

        return value;
    }

    private ValueModifierData GetValueModifierForLevel(int level)
    {
        if (level > valueModifiers[valueModifiers.Count - 1].levelStartEnd.y)
            return repeatLastModifier ? valueModifiers[valueModifiers.Count - 1] : new ValueModifierData();

        return valueModifiers
            .Find(val => val.levelStartEnd.x <= level && level <= val.levelStartEnd.y);
    }

#if UNITY_EDITOR
    private string GetInfo() =>
        getSumInfo ? GetInfoSum() : GetInfoPerLevel();

    private string GetInfoSum()
    {
        var sb = new StringBuilder();

        // sb.AppendLine($"Start Value: {startValue}");
        // sb.AppendLine($"Increase Values: {valueModifiers.Count}");

        foreach (var valueMod in valueModifiers)
        {
            var valueAtStart = Calculate(valueMod.levelStartEnd.x);
            var valueAtEnd = Calculate(valueMod.levelStartEnd.y + 1);
            sb.Append(
                $"LEVEL {valueMod.levelStartEnd.x} - {valueMod.levelStartEnd.y + 1}: " +
                $"[{valueMod.GetValue(valueMod.levelStartEnd.x)} - {valueMod.GetValue(valueMod.levelStartEnd.y + 1)}" +
                $" {valueMod.calculateType.ToString().ToUpper()}]");
            sb.AppendLine($" [{valueAtStart} - {valueAtEnd}]");
        }

        var start = valueModifiers[valueModifiers.Count - 1].levelStartEnd.y + 2;
        for (var level = start; level < start + 5; level++)
        {
            var value = Calculate(level);
            var valueMod = GetValueModifierForLevel(level);
            sb.AppendLine(
                $"LEVEL {level}: {value} " +
                $"[{valueMod.GetValue(level)} {valueMod.calculateType.ToString().ToUpper()}]");
        }

        sb.AppendLine("...");

        return sb.ToString();
    }

    private string GetInfoPerLevel()
    {
        var sb = new StringBuilder();

        if (valueModifiers.Count == 0)
        {
            sb.AppendLine("No value modifiers");
            return sb.ToString();
        }

        for (var level = 1; level <= valueModifiers[valueModifiers.Count - 1].levelStartEnd.y; level++)
        {
            var value = Calculate(level);
            var valueMod = GetValueModifierForLevel(level - 1);
            sb.AppendLine(level == 1 || level > 1 && valueMod != default
                ? $"LEVEL {level}: {value} [{valueMod.GetValue(level - 1)} {valueMod.calculateType.ToString().ToUpper()}]"
                : $"LEVEL {level}: [ERROR] NO VALUE MODIFIER ");
        }

        return sb.ToString();
    }
#endif

    private ValueModifierData AddNewValueModifier()
    {
        if (valueModifiers.Count == 0)
            return new ValueModifierData();

        var lastLevel = valueModifiers[valueModifiers.Count - 1].levelStartEnd.y + 1;
        return new ValueModifierData
        {
            levelStartEnd = new Vector2Int(lastLevel, lastLevel)
        };
    }
}

public enum CalculateType
{
    Flat,
    Multiplier,
}

[Serializable]
public struct ValueModifierData : IEquatable<ValueModifierData>
{
    public Vector2Int levelStartEnd;
    [EnumToggleButtons] public CalculateType calculateType;
    public float value;
    public bool hasSelfModifier;

    [ShowIf("hasSelfModifier")] [EnumToggleButtons]
    public CalculateType selfModCalculateType;

    [ShowIf("hasSelfModifier")] public float selfModValue;

    public float GetValue(int level)
    {
        if (!hasSelfModifier)
            return value;

        switch (selfModCalculateType)
        {
            case CalculateType.Multiplier:
                return value * Mathf.Pow(selfModValue, (level - levelStartEnd.x));
            case CalculateType.Flat:
            default:
                return value + selfModValue * (level - levelStartEnd.x);
        }
    }

    public bool Equals(ValueModifierData other) =>
        levelStartEnd.Equals(other.levelStartEnd) && calculateType == other.calculateType && value.Equals(other.value);

    public override bool Equals(object obj) =>
        obj is ValueModifierData other && Equals(other);

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + levelStartEnd.GetHashCode();
            hash = hash * 23 + (int)calculateType.GetHashCode();
            hash = hash * 23 + value.GetHashCode();
            return hash;
        }
    }

    public static bool operator ==(ValueModifierData left, ValueModifierData right) =>
        left.Equals(right);

    public static bool operator !=(ValueModifierData left, ValueModifierData right) =>
        !left.Equals(right);
}