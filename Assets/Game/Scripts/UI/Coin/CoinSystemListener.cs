using Crescive.Economics;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(1)]
public class CoinSystemListener : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CoinSystem coinSystem;

    [Header("Settings")]
    [SerializeField] private bool triggerOnceOnEnable = true;
    
    [Header("Events")]
    [SerializeField] private UnityEvent<int> OnCoinUpdated;

    private void OnEnable()
    {
        coinSystem.OnUpdated.AddListener(OnCoinUpdatedCallback);
        if (triggerOnceOnEnable)
            OnCoinUpdated?.Invoke(coinSystem.Coin);
    }

    private void OnDisable()
    {
        coinSystem.OnUpdated.RemoveListener(OnCoinUpdatedCallback);
    }

    private void OnCoinUpdatedCallback(int coin)
    {
        OnCoinUpdated?.Invoke(coin);
    }
}