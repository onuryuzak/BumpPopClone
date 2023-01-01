using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private FinishController finishController;
    [SerializeField] private CinemachineVirtualCamera shooterVcam;
    [SerializeField] private CinemachineVirtualCamera followVcam;

    [SerializeField] private ThrowControllerVariable throwControllerVariable;

    [SerializeField] private PlayerInputData playerInputData;
    public bool gameFinish;

    private void Start()
    {
        shooterVcam.m_Priority = 11;
        followVcam.m_Priority = 0;
    }

    private void Update()
    {
        if (gameFinish) return;
        if (playerInputData.Released)
        {
            followVcam.m_Priority = 11;
            shooterVcam.m_Priority = 0;
        }

        if (playerInputData.Tapped)
        {
            shooterVcam.m_Priority = 11;
            followVcam.m_Priority = 0;
        }

        if (throwControllerVariable.Value.CurrentBall == null) return;
        shooterVcam.m_Follow = throwControllerVariable.Value.CurrentBall.transform;
        shooterVcam.m_LookAt = throwControllerVariable.Value.CurrentBall.transform;
        followVcam.m_Follow = throwControllerVariable.Value.CurrentBall.transform;
    }

    public void OnGameFinish()
    {
        gameFinish = true;
        followVcam.m_Follow = finishController.finishedBalls[0].transform;
        followVcam.transform.rotation = Quaternion.AngleAxis(33,Vector3.right);
        CinemachineTransposer transposer = followVcam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_BindingMode = CinemachineTransposer.BindingMode.WorldSpace;
        transposer.m_FollowOffset = new Vector3(0, 32, -49);
        transposer.m_XDamping = 5;
        transposer.m_YDamping = 5;
        transposer.m_ZDamping = 5;
        CinemachineComposer composer = followVcam.GetCinemachineComponent<CinemachineComposer>();
        composer.m_HorizontalDamping = 5;
        composer.m_VerticalDamping = 5;
    }
}