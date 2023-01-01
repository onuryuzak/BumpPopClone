using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;


public class BallRotationController : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [FoldoutGroup("References")] [SerializeField]
    private Transform rotationTransform;

    [FoldoutGroup("References")] [SerializeField]
    private Ball ball;

    [FoldoutGroup("References")] [SerializeField]
    private PlayerInputData playerInputData;

    #endregion

    #region PRIVATE FIELDS

    private bool canMove = true;
    private bool canRotate = true;
    private Vector3 moveOffset;
    private float horizontalInput;
    private bool mustPerformInput;
    private bool gameFinish;

    #endregion

    #region PUBLIC PROPERTIES

    #endregion

    #region UNITY METHODS

    private void Update()
    {
        if (ball.BallType != BallType.ThrowableBall) return;
        if (gameFinish) return;
        ReadInput();
        HandleRotation();
    }

    #endregion

    #region PRIVATE METHODS

    private void HandleRotation()
    {
        if (mustPerformInput)
        {
            Rotate();
            mustPerformInput = false;
        }
    }

    private void ReadInput()
    {
        canMove = playerInputData.Holding;
        if (!mustPerformInput)
        {
            horizontalInput = playerInputData.Horizontal;
            mustPerformInput = true;
        }
    }

    private void Rotate()
    {
        if (!canMove)
        {
            return;
        }

        if (horizontalInput == 0) return;
        rotationTransform.Rotate(Vector3.up,
            horizontalInput * Mathf.Rad2Deg * playerInputData.rotationAmount * Time.deltaTime);
    }

    #endregion

    #region PUBLIC METHODS

    public void OnGameFinish()
    {
        gameFinish = true;
    }

    #endregion
}