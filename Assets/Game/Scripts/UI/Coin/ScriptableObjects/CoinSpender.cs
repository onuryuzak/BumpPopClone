using System;
using Crescive.Economics;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinSpender", menuName = "GameData/Coin/CoinSpender")]
public class CoinSpender : ScriptableObject
{
    [Header("References")]
    [SerializeField] private CoinSystem coinSystem;
    [SerializeField] private CoinEvents coinEvents;

    public bool TrySpend(int amount) => 
        TrySpend(amount, null, null);
    
    public bool TrySpendWorldPos(int amount, Vector3? pos) => 
        TrySpend(amount, pos, coinEvents.DecreaseCoinAmountWorldPos);
    
    public bool TrySpendCanvasPos(int amount, Vector3? pos) => 
        TrySpend(amount, pos, coinEvents.DecreaseCoinAmountCanvasPos);

    private bool TrySpend(int amount, Vector3? pos, Action<int, Vector3> amountPosAction)
    {
        if (!CanSpendCoin(amount))
            return false;

        if (pos != null)
            amountPosAction(amount, (Vector3)pos);
        else
            coinEvents.DecreaseCoin(amount);

        return true;
    }

    public bool CanSpendCoin(int amount) => 
        coinSystem.Coin >= amount;
}