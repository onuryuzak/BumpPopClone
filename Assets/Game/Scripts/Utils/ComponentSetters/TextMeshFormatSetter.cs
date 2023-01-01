using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class TextMeshFormatSetter : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private bool useTextMeshPro3D;

    [ShowIf("useTextMeshPro3D")] [SerializeField]
    private TextMeshPro textMeshPro;

    [ShowIf("@!useTextMeshPro3D")] [SerializeField]
    private TextMeshProUGUI textMesh;

    [SerializeField] private string prefix;
    [SerializeField] private string postFix;

    #endregion

    #region PUBLIC METHODS

    public void SetText(string text) => ConstructText(text);
    public void SetText(int value) => ConstructText(value.ToString());
    public void SetText(float value) => ConstructText(value.ToString());
    public void SetTextInt(float value) => ConstructText(((int) value).ToString());

    #endregion

    #region PRIVATE METHODS

    private void ConstructText(string text)
    {
        text = $"{prefix}{text}{postFix}";
        if (useTextMeshPro3D)
            textMeshPro.text = text;
        else
            textMesh.text = text;
    }

    #endregion
}