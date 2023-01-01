using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.Linq;
using Sirenix.OdinInspector;
#endif

public class LevelingResetter : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private List<LevelingDataResetData> data;

    [Header("Settings")] [SerializeField] private bool resetOnAwake = true;

    private void Awake()
    {
        if (!resetOnAwake)
            return;

        ResetValues();
    }

    private void ResetValues()
    {
        foreach (var resetData in data)
            resetData.LevelingData.SetLevel(resetData.ResetLevel);
    }
}


[Serializable]
public struct LevelingDataResetData
{
    public LevelingData LevelingData;
    public int ResetLevel;

    public LevelingDataResetData(LevelingData levelingData)
    {
        LevelingData = levelingData;
        ResetLevel = 1;
    }
}