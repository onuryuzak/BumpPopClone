
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeLevelingData", menuName = "ScriptableObjects/Leveling/Upgrade/UpgradeLevelingData")]
public class UpgradeLevelingData : ScriptableObject
{
    [Header("References")]
    [SerializeField] private LevelingFloat mainLevelingFloat;
    [SerializeField] private LevelingFloat costLeveling;

    public LevelingFloat MainLevelingFloat => mainLevelingFloat;
    public LevelingFloat CostLeveling => costLeveling;
}