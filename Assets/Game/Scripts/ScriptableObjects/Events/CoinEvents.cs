using UnityAtoms.BaseAtoms;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinEvents", menuName = "GameData/Event/CoinEvents")]
public class CoinEvents : ScriptableObject
{
    [Header("Events")]
    [SerializeField] private IntEvent increaseCoinEvent;
    [SerializeField] private IntEvent decreaseCoinEvent;
    [SerializeField] private Vector3Event increaseCoinWorldPosEvent;
    [SerializeField] private Vector3Event increaseCoinCanvasPosEvent;
    [SerializeField] private IntVector3PairEvent increaseCoinAmountWorldPosEvent;
    [SerializeField] private IntVector3PairEvent increaseCoinAmountCanvasPosEvent;
    [SerializeField] private IntVector3PairEvent decreaseCoinAmountWorldPosEvent;
    [SerializeField] private IntVector3PairEvent decreaseCoinAmountCanvasPosEvent;
    
    public void IncreaseCoin(int amount)
    {
        increaseCoinEvent.Raise(amount);
    }

    public void DecreaseCoin(int amount)
    {
        decreaseCoinEvent.Raise(amount);
    }

    public void IncreaseCoinWorldPos(Vector3 pos)
    {
        increaseCoinWorldPosEvent.Raise(pos);
    }

    public void IncreaseCoinCanvasPos(Vector3 pos)
    {
        increaseCoinCanvasPosEvent.Raise(pos);
    }

    public void IncreaseCoinAmountWorldPos(int amount, Vector3 pos)
    {
        increaseCoinAmountWorldPosEvent.Raise(new IntVector3Pair(amount, pos));
    }

    public void IncreaseCoinAmountCanvasPos(int amount, Vector3 pos)
    {
        increaseCoinAmountCanvasPosEvent.Raise(new IntVector3Pair(amount, pos));
    }

    public void DecreaseCoinAmountWorldPos(int amount, Vector3 pos)
    {
        decreaseCoinAmountWorldPosEvent.Raise(new IntVector3Pair(amount, pos));
    }
    
    public void DecreaseCoinAmountCanvasPos(int amount, Vector3 pos)
    {
        decreaseCoinAmountCanvasPosEvent.Raise(new IntVector3Pair(amount, pos));
    }
}