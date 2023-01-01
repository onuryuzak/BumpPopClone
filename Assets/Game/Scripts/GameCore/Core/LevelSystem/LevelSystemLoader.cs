using UnityEngine;
using UnityEngine.Events;


public class LevelSystemLoader : Singleton<LevelSystemLoader>
{
    #region INSPECTOR FIELDS

    [SerializeField] protected LevelSystem levelSystem;

    #endregion

    #region PUBLIC EVENTS

    public UnityEvent BeforeLoadingStartedEvent;
    public UnityEvent LevelLoadingStartedEvent;
    public LevelSystem.LevelDataUnityEvent LevelLoadedEvent;
    public LevelSystem.LevelDataUnityEvent LevelUnLoadedEvent;

    #endregion

    #region LIFECYCLE METHODS

    protected override void Awake()
    {
        dontDestroyOnLoad = true;
        base.Awake();
    }

    private void Start() => HandleLevelSystemLoading();

    protected override void OnInstanceCreated()
    {
        base.OnInstanceCreated();
        SubscribeEvents();
        levelSystem.ClearRuntimeData();
        OnBeforeLoadingStarted();
    }

    protected override void OnInstanceDestroyed()
    {
        base.OnInstanceDestroyed();
        UnSubscribeEvents();
        levelSystem.ClearRuntimeData();
    }

    #endregion

    #region PROTECTED VIRTUAL METHODS

    protected virtual void OnBeforeLoadingStarted() => BeforeLoadingStartedEvent?.Invoke();

    protected virtual void OnLevelLoadingStarted() => LevelLoadingStartedEvent?.Invoke();

    protected virtual void OnLevelLoaded(LevelData level) => LevelLoadedEvent?.Invoke(level);

    protected virtual void OnLevelUnLoaded(LevelData level) => LevelUnLoadedEvent?.Invoke(level);

    #endregion

    #region PRIVATE METHODS

    private void HandleLevelSystemLoading()
    {
        levelSystem.LoadLastSavedLevel();
    }

    private void SubscribeEvents()
    {
        levelSystem.onLevelLoadingStarted.AddListener(OnLevelLoadingStarted);
        levelSystem.onLevelLoaded.AddListener(OnLevelLoaded);
        levelSystem.onLevelUnloaded.AddListener(OnLevelUnLoaded);
    }

    private void UnSubscribeEvents()
    {
        levelSystem.onLevelLoadingStarted.RemoveListener(OnLevelLoadingStarted);
        levelSystem.onLevelLoaded.RemoveListener(OnLevelLoaded);
        levelSystem.onLevelUnloaded.RemoveListener(OnLevelUnLoaded);
    }

    #endregion
}