using Sirenix.OdinInspector;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    #region INSPECTOR FIELDS

    [SerializeField] private GameStateEvents gameStateEvents;
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private bool autoStartGame = true;

    #endregion

    #region PRIVATE FIELDS

    private bool started;
    private bool finished;
    private bool won;

    #endregion

    #region PUBLIC PROPERTIES

    public bool Finished => finished;
    public bool Started => started;
    public bool Won => won;

    #endregion

    #region PUBLIC METHODS

    [Button]
    public void Play() => gameStateEvents.TriggerPlayEvent();

    [Button]
    public void Win()
    {
        if (finished)
            return;

        gameStateEvents.TriggerWinEvent();
    }

    [Button]
    public void GameOver()
    {
        if (finished)
            return;

        gameStateEvents.TriggerGameOverEvent();
    }

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        gameStateEvents.OnPlay.AddListener(OnPlay);
        gameStateEvents.OnPause.AddListener(OnPause);
        gameStateEvents.OnWin.AddListener(OnWin);
        gameStateEvents.OnGameOver.AddListener(OnGameOver);
    }

    private void OnDisable()
    {
        gameStateEvents.OnPlay.RemoveListener(OnPlay);
        gameStateEvents.OnPause.RemoveListener(OnPause);
        gameStateEvents.OnWin.RemoveListener(OnWin);
        gameStateEvents.OnGameOver.RemoveListener(OnGameOver);
    }

    private void Start()
    {
        if (autoStartGame)
            Play();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (Finished && Won)
            levelSystem.SaveNextLevel();
    }

    private void OnApplicationQuit()
    {
        if (Finished && Won)
            levelSystem.SaveNextLevel();
    }

    #endregion

    #region GAMESTATE CALLBACKS

    private void OnBeginning()
    {
    }

    private void OnPlay()
    {
        started = true;
    }

    private void OnPause()
    {
    }

    private void OnWin()
    {
        finished = true;
        won = true;
    }

    private void OnGameOver()
    {
        finished = true;
    }

    #endregion
}