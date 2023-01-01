using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private RaycastReflection raycastReflection;
    [SerializeField] private float power;
    [SerializeField] private BallType ballType;

    #endregion

    #region UNITY EVENTS

    [FoldoutGroup("Unity EVENTS")] public UnityEvent OnBallSpawn;

    [FoldoutGroup("Unity EVENTS")] [SerializeField]
    private UnityEvent OnBallRelase;

    [FoldoutGroup("Unity EVENTS")] [SerializeField]
    private UnityEvent OnBallHandle;

    #endregion

    #region PUBLIC PROPERTIES

    public BallType BallType
    {
        get => ballType;
        set => ballType = value;
    }

    public bool IsCurrentBall
    {
        get => isCurrentBall;
        set => isCurrentBall = value;
    }

    #endregion

    #region PUBLIC FIELDS

    public Rigidbody ballRigidbody;

    #endregion

    #region PRIVATE FIELDS

    private bool isCurrentBall;

    #endregion

    #region PUBLIC METHODS

    public void Move()
    {
        if (!isCurrentBall) return;
        OnBallRelase?.Invoke();
        ballRigidbody.AddForce(CalculateForce(), ForceMode.VelocityChange);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.one);
    }

    public void Stop()
    {
        if (!isCurrentBall) return;
        OnBallHandle?.Invoke();
        Transform currentBallParent = transform.parent;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        currentBallParent.rotation = Quaternion.AngleAxis(0, Vector3.one);
        var tempPos = currentBallParent.position;
        tempPos.y = 0;
        currentBallParent.position = tempPos;
    }

    public void OnFinishLine()
    {
        ballRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                                    RigidbodyConstraints.FreezeRotationZ;
        ballRigidbody.angularDrag = 0;
        ballRigidbody.drag = 0;
        var constantForce = gameObject.transform.parent.gameObject.AddComponent<ConstantForce>();
        constantForce.force = new Vector3(0, -60f, 30f);

        DOVirtual.DelayedCall(0.7f, (() => constantForce.enabled = false));
        enabled = false;
    }

    #endregion

    #region PRIVATE METHODS

    private Vector3 CalculateForce()
    {
        return transform.forward * power;
    }

    #endregion
}

public enum BallType
{
    ThrowableBall,
    InstantiatorBall
}