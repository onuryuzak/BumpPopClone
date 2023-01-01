using UnityEngine;

namespace Crescive.KnivesOut
{
    public class PopUpItem : MonoBehaviour
    {
        [SerializeField] private TextMeshFormatSetter increaseTextSetter;

        public void DisplayIncreasePopUp(int amount)
        {
            increaseTextSetter.gameObject.SetActive(true);

            increaseTextSetter.SetText(amount);
        }
    }
}