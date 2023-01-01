using UnityEngine;
using UnityEngine.Animations;

public class LookAtConstraintCameraProvider : MonoBehaviour
{
    [SerializeField] private LookAtConstraint lookAtConstraint;

    private void Awake()
    {
        lookAtConstraint.AddSource(new ConstraintSource { sourceTransform = Camera.main.transform, weight = 1 });
        lookAtConstraint.constraintActive = true;
        transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
    }
}