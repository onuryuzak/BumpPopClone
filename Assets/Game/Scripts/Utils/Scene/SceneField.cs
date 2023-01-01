using System;
using UnityEngine;
using Object = UnityEngine.Object;


[Serializable]
public class SceneField
{
    [SerializeField] Object m_sceneAsset;
    [SerializeField] string m_sceneName = "";

    public string SceneName
    {
        get { return m_sceneName; }
    }

    public static implicit operator string(SceneField sceneField)
    {
        return sceneField.SceneName;
    }
}