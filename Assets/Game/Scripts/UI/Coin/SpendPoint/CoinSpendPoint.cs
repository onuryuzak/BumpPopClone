using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpendPoint : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [Header("References")]
    [SerializeField] private CoinSpender coinSpender;
    [SerializeField] private Transform spendTransform;

    [Header("Settings")]
    [SerializeField] private IntReference spendAmount;

    [Header("Events")]
    public UnityEvent OnCoinSpent;
    public UnityEvent OnCoinSpendFailed;
    public UnityEvent OnCanSpend;
    public UnityEvent OnCanNotSpend;

    #endregion

    #region PRIVATE PROPERTIES

    private bool canSpend = true;

    #endregion

    #region PUBLIC PROPERTIES

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        CheckCanSpend();
    }

    #endregion

    #region PRIVATE METHODS

    private void InvokeSpendEvent(bool didSpend)
    {
        if (didSpend)
        {
            OnCoinSpent?.Invoke();
            CheckCanSpend();
        }
        else
            OnCoinSpendFailed?.Invoke();
    }

    #endregion

    #region PUBLIC METHODS

    public void TrySpend()
    {
        var didSpend = coinSpender.TrySpend(spendAmount);
        InvokeSpendEvent(didSpend);
    }

    public void TrySpendWorldPos()
    {
        var didSpend = coinSpender.TrySpendWorldPos(spendAmount, spendTransform.position);
        InvokeSpendEvent(didSpend);
    }

    public void TrySpendCanvasPos()
    {
        var didSpend = coinSpender.TrySpendCanvasPos(spendAmount, spendTransform.position);
        InvokeSpendEvent(didSpend);
    }

    public void CheckCanSpend()
    {
        var canSpendNew = coinSpender.CanSpendCoin(spendAmount.Value);

        if (canSpend == canSpendNew)
            return;

        canSpend = canSpendNew;

        if (canSpend)
            OnCanSpend?.Invoke();
        else
            OnCanNotSpend?.Invoke();
    }

    #endregion
}