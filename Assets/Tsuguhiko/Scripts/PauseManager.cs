using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public static class PauseManager
{
    private static bool isPaused = false;
    private static List<Tween> activeTweeners = new List<Tween>();
  //  private static EventSystem eventSystem;
   // private static TMP_Text _pauseText;
    private static GameObject _pausePanel; 

    public static void Initialize(EventSystem eventSystem, GameObject pausePanel) 
    {
       // PauseManager.eventSystem = eventSystem;
       // _pauseText = text;
        _pausePanel = pausePanel; 

        //if (_pauseText != null)
        //{
        //    _pauseText.enabled = false;
        //}

        if (_pausePanel != null)
        {
            _pausePanel.SetActive(false);
        }
    }

    public static void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    private static void Pause()
    {
        isPaused = true;

        // Disable the EventSystem
        //if (eventSystem != null)
        //{
        //    eventSystem.enabled = false;
        //}

        // Pause all DOTween animations
        activeTweeners.Clear();
        List<Tween> playingTweens = DOTween.PlayingTweens();
        if (playingTweens != null)
        {
            activeTweeners.AddRange(playingTweens);
        }
        if (_pausePanel != null)
        {
            _pausePanel.SetActive(true);
        }
        DOTween.PauseAll();

        // Optionally, you can also set Time.timeScale to 0 to pause all in-game activities
        // Time.timeScale = 0;
    }

    public static void Unpause()
    {
        isPaused = false;

        // Enable the EventSystem
        //if (eventSystem != null)
        //{
        //    eventSystem.enabled = true;
        //}

        if (_pausePanel != null)
        {
            _pausePanel.SetActive(false);
        }

        // Resume all DOTween animations
        foreach (Tween tween in activeTweeners)
        {
            if (tween != null && tween.IsActive())
            {
                tween.Play();
            }
        }

        // Optionally, you can also set Time.timeScale back to 1 to resume all in-game activities
        // Time.timeScale = 1;
    }
}
