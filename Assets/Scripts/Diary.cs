using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public GameObject diary;
    public GameObject flipButton;
    public GameObject[] diaryNotes;

    bool active;

    private void Start()
    {
        active = false;
    }

    public void OpenOrCloseDiary()
    {
        if (!active)
        {
            diary.gameObject.SetActive(true);
            flipButton.gameObject.SetActive(true);

            active = true;
        }
        else
        {
            diary.gameObject.SetActive(false);
            flipButton.gameObject.SetActive(false);
            
            active = false;
        }
    }

    private void SetNextNoteActive()
    {
        for (int i = 0; i < diaryNotes.Length; i++)
        {
            if (!diaryNotes[i].gameObject.activeSelf)
            {
                diaryNotes[i].SetActive(true);
                break;
            }
        }
    }

    private void OnEnable()
    {
        ResearchObjectManager.itemClicked += SetNextNoteActive;
    }

    private void OnDisable()
    {
        ResearchObjectManager.itemClicked -= SetNextNoteActive;
    }

}
