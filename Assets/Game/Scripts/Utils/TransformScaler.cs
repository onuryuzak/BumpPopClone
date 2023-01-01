using UnityEngine;


public class TransformScaler : MonoBehaviour
{
    public void Scale(float scale) => transform.localScale = Vector3.one * scale;
    public void Scale(Vector3 scale) => transform.localScale = scale;
}