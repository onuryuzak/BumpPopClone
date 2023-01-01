using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseSceneLoader : ScriptableObject
{
    public abstract void LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive,
        Action onComplete = null);

    public abstract void UnloadSceneAsync(string sceneName, Action onComplete = null);

    public abstract Scene GetScene(string sceneName);

    public abstract void ClearRuntimeData();
}