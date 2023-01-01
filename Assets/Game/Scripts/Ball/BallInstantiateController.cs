using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BallInstantiateController : MonoBehaviour
{
    [SerializeField] private Ball spawnerBall;
    [SerializeField] private float addForceValue;
    [SerializeField] private LevelingData countLevelingData;
    [SerializeField] private LevelingData incomeLevelingData;
    [SerializeField] private GameObjectFactory ballFactory;
    [SerializeField] private ThrowControllerVariable throwControllerVariable;
    [SerializeField] private IntEvent coinIncreaseEvent;
    [SerializeField] private BallColorSetter mainColorSetter;

    public void CreateBalls(Collision other)
    {
        var otherBall = other.gameObject.GetComponentInChildren<Ball>();
        if (otherBall.BallType == BallType.ThrowableBall)
        {
            for (int i = 0; i < countLevelingData.Value + 3; i++)
            {
                var spawnedBall = ballFactory.Create();
                Vector3 tempPos = transform.position + Random.insideUnitSphere;
                tempPos.y = transform.position.y;
                spawnedBall.transform.position = tempPos;


                BallColorSetter ballColorSetter = spawnedBall.GetComponent<BallColorSetter>();
                ballColorSetter.SetPropertyColor(mainColorSetter.currentColor);

                Ball ball = spawnedBall.GetComponentInChildren<Ball>();
                ball.OnBallSpawn?.Invoke();

                ball.BallType = BallType.ThrowableBall;
                throwControllerVariable.Value.SceneBalls.Add(ball);
                ball.ballRigidbody.AddForce(ball.transform.forward * addForceValue, ForceMode.VelocityChange);
                coinIncreaseEvent.Raise(incomeLevelingData.Value);
            }

            spawnerBall.BallType = BallType.ThrowableBall;
            throwControllerVariable.Value.SceneBalls.Add(spawnerBall);
        }
    }
}