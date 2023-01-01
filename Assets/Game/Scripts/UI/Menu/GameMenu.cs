using System;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;


public class GameMenu : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private GameStateEvents gameStateEvents;


    [FoldoutGroup("Panels")] [SerializeField]
    private GameObject levelCompletePanel;


    [SerializeField] private float winPanelOpenDelay = 2.5f;
    [SerializeField] private float winPanelOpenDuration = .7f;

    #endregion

    #region PRIVATE FIELDS

    private GameObject activePanel;
    private bool gameFinished;

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        gameStateEvents.OnWin.AddListener(OnGameWin);
        gameStateEvents.OnGameOver.AddListener(OnGameOver);
    }

    private void OnDisable()
    {
        gameStateEvents.OnWin.RemoveListener(OnGameWin);
        gameStateEvents.OnGameOver.RemoveListener(OnGameOver);
    }

    #endregion

    #region PUBLIC METHODS

    public void LoadNextLevel() => levelSystem.LoadNextLevel();

    public void RestartLevel() => levelSystem.RestartLevel();

    #endregion

    #region PRIVATE METHODS

    private IEnumerator OpenPanelDelayed(GameObject panel, float delay, float duration)
    {
        yield return new WaitForSecondsRealtime(delay);
        OpenPanel(panel, duration);
    }

    private void OpenPanel(GameObject panel, float duration)
    {
        if (activePanel)
            activePanel.SetActive(false);

        activePanel = panel;
        activePanel.SetActive(true);
        AnimatePanel(activePanel.transform, duration);
    }

    private void AnimatePanel(Transform panel, float duration)
    {
        panel.localScale = Vector3.right;
        panel.DOScale(Vector3.one, duration).SetEase(Ease.OutElastic).SetUpdate(true);
    }

    #endregion

    #region CALLBACK METHODS

    private void OnGameWin()
    {
        if (gameFinished)
            return;
        gameFinished = true;
        StartCoroutine(OpenPanelDelayed(levelCompletePanel, winPanelOpenDelay, winPanelOpenDuration));
    }

    private void OnGameOver()
    {
        if (gameFinished)
            return;
        gameFinished = true;
    }

    #endregion
}