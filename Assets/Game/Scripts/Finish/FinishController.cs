using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField] private ThrowControllerVariable throwControllerVariable;
    [SerializeField] private VoidEvent OnGameFinish;
    [SerializeField] private GameStateEvents gameStateEvents;

    private bool repeatOneTime;
    public List<Ball> finishedBalls;

    public void OnBallEnter(Collider other)
    {
        var ball = other.GetComponentInParent<Ball>();
        finishedBalls.Add(ball);
        if (!repeatOneTime)
        {
            repeatOneTime = true;
            GameFinish();
            OnGameFinish.Raise();
        }

        throwControllerVariable.Value.enabled = false;
        ball.OnFinishLine();
    }

    private void GameFinish()
    {
        DOVirtual.DelayedCall(1f, (() => gameStateEvents.TriggerWinEvent()));
    }
}