using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainTheme;
    public AudioSource ambience;

    void Start()
    {
        mainTheme = GetComponent<AudioSource>();
        ambience = GetComponent<AudioSource>();

        ambience.Play();
    }
}
