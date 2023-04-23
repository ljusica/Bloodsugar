using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCaller : MonoBehaviour
{
    [SerializeField] private Button _continueButton;

    [SerializeField] private Button _exitButton;

    [SerializeField] private FadeInImageMono _fadeInImageMono; // Add this line
    public void Continue()
    {
        PauseManager.Unpause();
    }

    public void ExitCall()
    {
        // Moving or fading out a scene

        StartCoroutine(_fadeInImageMono.FadeOut()); 
    }
}
