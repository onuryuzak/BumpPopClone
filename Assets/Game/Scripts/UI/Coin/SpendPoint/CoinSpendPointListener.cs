using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class CoinSpendPointListener : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CoinSpendPoint coinSpendPoint;

    [Header("Events")]
    [SerializeField] private UnityEvent OnCoinSpent;
    [SerializeField] private UnityEvent OnCoinSpendFailed;
    [SerializeField] private UnityEvent OnCanSpend;
    [SerializeField] private UnityEvent OnCanNotSpend;

    private void OnEnable()
    {
        coinSpendPoint.OnCoinSpent.AddListener(OnCoinSpentHandler);
        coinSpendPoint.OnCoinSpendFailed.AddListener(OnCoinSpendFailedHandler);
        coinSpendPoint.OnCanSpend.AddListener(OnCanSpendHandler);
        coinSpendPoint.OnCanNotSpend.AddListener(OnCanNotSpendHandler);
    }

    private void OnDisable()
    {
        coinSpendPoint.OnCoinSpent.RemoveListener(OnCoinSpentHandler);
        coinSpendPoint.OnCoinSpendFailed.RemoveListener(OnCoinSpendFailedHandler);
        coinSpendPoint.OnCanSpend.RemoveListener(OnCanSpendHandler);
        coinSpendPoint.OnCanNotSpend.RemoveListener(OnCanNotSpendHandler);
    }

    private void OnCoinSpentHandler()
    {
        OnCoinSpent?.Invoke();
    }

    private void OnCoinSpendFailedHandler()
    {
        OnCoinSpendFailed?.Invoke();
    }

    private void OnCanSpendHandler()
    {
        OnCanSpend?.Invoke();
    }

    private void OnCanNotSpendHandler()
    {
        OnCanNotSpend?.Invoke();
    }
}