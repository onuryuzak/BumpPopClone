using PersistentSO;
using UnityEngine;

namespace Crescive.KnivesOut
{
    public class PopUpDisplayer : MonoBehaviour
    {
        [SerializeField] private ObjectPoolerBehaviour pooler;
        [SerializeField] private bool dontDisplayOnZeroAmount = true;

        public void DisplayIncreasePopUp(PersistentIntVariable amount)
        {
            if (dontDisplayOnZeroAmount && amount.Value == 0)
                return;

            var popUp = pooler.Spawn<PopUpItem>();
            if (popUp)
                popUp.DisplayIncreasePopUp(amount.Value);
        }
    }
}