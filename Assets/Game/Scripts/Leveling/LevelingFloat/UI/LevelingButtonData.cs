using UnityEngine;

[CreateAssetMenu(fileName = "LevelingButtonData", menuName = "ScriptableObjects/Leveling/UI/LevelingButtonData")]
public class LevelingButtonData : ScriptableObject
{
    [Header("References")] [SerializeField]
    private UpgradeLevelingData upgradeLevelingData;

    [Header("Settings")] [SerializeField] private string title;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite background;

    public string Title => title;
    public Sprite Icon => icon;
    public Sprite Background => background;

    public LevelingFloat MainLevelingFloat => upgradeLevelingData.MainLevelingFloat;
    public LevelingFloat CostLeveling => upgradeLevelingData.CostLeveling;
}