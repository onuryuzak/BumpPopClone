using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class ThrowController : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private PlayerInputData playerInputData;
    [SerializeField] private Ball initBall;

    [FoldoutGroup("Atom EVENTS")] [SerializeField]
    private VoidEvent OnBallRelase;

    [FoldoutGroup("Atom EVENTS")] [SerializeField]
    private VoidEvent OnBallHandle;

    #endregion

    #region PRIVATE FIELDS

    private List<Ball> sceneBalls = new List<Ball>();

    private Ball currentBall;

    private bool gameStart;

    private bool farthestObjectFound;

    #endregion

    #region PUBLIC PROPERTIES

    public Ball CurrentBall
    {
        get => currentBall;
        set => currentBall = value;
    }

    public List<Ball> SceneBalls => sceneBalls;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        currentBall = initBall;
        currentBall.IsCurrentBall = true;
        sceneBalls.Add(currentBall);
    }

    void Update()
    {
        if (!gameStart) return;

        if (!farthestObjectFound)
        {
            var farthestThrowableBall = sceneBalls.OrderByDescending(x => x.transform.position.sqrMagnitude).First();
            currentBall = farthestThrowableBall;
        }


        if (playerInputData.Tapped)
        {
            currentBall.transform.parent.rotation = Quaternion.AngleAxis(0, Vector3.one);
            currentBall.IsCurrentBall = true;
            farthestObjectFound = true;
            for (int i = 0; i < sceneBalls.Count; i++)
            {
                sceneBalls[i].ballRigidbody.velocity = Vector3.zero;
            }
        }

        if (playerInputData.Released)
        {
            OnBallRelase.Raise();
            farthestObjectFound = false;
            currentBall.IsCurrentBall = false;
            currentBall = null;
        }

        if (playerInputData.Holding)
        {
            OnBallHandle.Raise();
        }
    }

    #endregion

    #region PUBLIC METHODS

    public void GameStart()
    {
        DOVirtual.DelayedCall(0.3f, (() => gameStart = true));
    }

    #endregion
}