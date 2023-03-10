using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectFactory", menuName = "ScriptableObjects/Factory/GameObjectFactory")]
public class GameObjectFactory : ScriptableObject
{
    [SerializeField] private bool usePooler;

    [SerializeField] [ShowIf("usePooler")] [RequireInterface(typeof(IObjectPooler))]
    private Object pooler;

    [SerializeField] [HideIf("usePooler")] private GameObject prefab;

    private IObjectPooler Pooler => pooler as IObjectPooler;

    public GameObject Prefab => usePooler ? Pooler.Prefab : prefab;

    public GameObject Create(Vector3? pos = null, Quaternion? rot = null, Vector3? scale = null,
        Transform parent = null)
    {
        GameObject obj;
        if (usePooler)
        {
            obj = Pooler.Spawn();
            obj.transform.SetParent(parent);

            if (pos.HasValue)
                obj.transform.position = pos.Value;

            if (rot.HasValue)
                obj.transform.rotation = rot.Value;

            if (scale.HasValue)
                obj.transform.localScale = scale.Value;
        }
        else
        {
            obj = Instantiate(prefab, parent);

            if (pos.HasValue)
                obj.transform.position = pos.Value;

            if (rot.HasValue)
                obj.transform.rotation = rot.Value;

            if (scale.HasValue)
                obj.transform.localScale = scale.Value;
        }

        return obj;
    }

    public TComponent Create<TComponent>(Vector3? pos = null, Quaternion? rot = null, Vector3? scale = null,
        Transform parent = null)
        where TComponent : Component =>
        Create(pos, rot, scale, parent).GetComponent<TComponent>();

    public void CreateAtTarget(Transform target) => Create(target.position);
    public void CreateAtPosition(Vector3 pos) => Create(pos);
    public void CreateAtPositionWithScaleFloat(Vector3 pos, float scale) => Create(pos, null, Vector3.one * scale);
    public void CreateAtPositionWithScaleFloat(Vector3 pos, Vector3 scale) => Create(pos, null, scale);
}

public abstract class GameObjectFactory<TComponent> : ScriptableObject where TComponent : Component
{
    [SerializeField] private TComponent prefab;

    public TComponent Prefab => prefab;

    public TComponent Create(Vector3? pos = null, Quaternion? rot = null, Transform parent = null)
    {
        var obj = Instantiate(prefab, parent);

        if (pos.HasValue)
            obj.transform.position = pos.Value;

        if (rot.HasValue)
            obj.transform.rotation = rot.Value;

        return obj;
    }

    public void CreateAtTarget(Transform target) => Create(target.position, Quaternion.identity);
    public void CreateAtPosition(Vector3 pos) => Create(pos, Quaternion.identity);
}