using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public GameObject diary;
    public GameObject[] diaryNotes;
    public GameObject flipForwardsButton;
    public GameObject flipBackwardsButton;

    private GameObject[] enabledDiaryNotes;

    bool[] noteEnabled = { false, false, false, false, false, false, false };

    private void Start()
    {
        enabledDiaryNotes = new GameObject[7];
    }

    public void OpenOrCloseDiary()
    {
        diary.gameObject.SetActive(!diary.gameObject.activeSelf);
        flipBackwardsButton.gameObject.SetActive(false);
        flipForwardsButton.gameObject.SetActive(false);

        if (enabledDiaryNotes[0] == diaryNotes[0])
        {
            enabledDiaryNotes[0].gameObject.SetActive(diary.gameObject.activeSelf);

            if (noteEnabled[1]) { flipForwardsButton.gameObject.SetActive(true); }
        }

        if(!diary.gameObject.activeSelf)
        {
            foreach(GameObject note in enabledDiaryNotes) 
            { 
                if(note != null)
                {
                    if(note.activeSelf)
                        note.SetActive(false); 
                }
            }
        }
    }

    public void FlipForwards()
    {
        //TODO: Do some flip-animation
        if (enabledDiaryNotes != null)
        {
            for (int i = 0; i < enabledDiaryNotes.Length; i++)
            {
                if (enabledDiaryNotes[i] == null) { continue; }
                if (enabledDiaryNotes[i].gameObject.activeSelf)
                {
                    enabledDiaryNotes[i].gameObject.SetActive(false);

                    if ((i + 1) <= enabledDiaryNotes.Length && noteEnabled[i + 1] != false)
                    {
                        enabledDiaryNotes[i + 1].gameObject.SetActive(true);
                        flipBackwardsButton.gameObject.SetActive(true);

                        if ((i + 2) >= enabledDiaryNotes.Length || noteEnabled[i + 2] != true)
                        {
                            flipForwardsButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            flipForwardsButton.gameObject.SetActive(true);
                        }

                        break;
                    }
                }
            }
        }
    }

    public void FlipBackwards()
    {
        //TODO: Do some flip-animation

        if (enabledDiaryNotes != null)
        {
            for (int i = 0; i < enabledDiaryNotes.Length; i++)
            {
                if (enabledDiaryNotes[i] == null) { continue; }
                if (enabledDiaryNotes[i].gameObject.activeSelf)
                {
                    enabledDiaryNotes[i].gameObject.SetActive(false);
                    if (noteEnabled[i]) { flipForwardsButton.gameObject.SetActive(true); }

                    if ((i - 1) >= 0)
                    {
                        enabledDiaryNotes[i - 1].gameObject.SetActive(true);

                        if ((i - 2) < 0)
                        {
                            flipBackwardsButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            flipBackwardsButton.gameObject.SetActive(true);
                        }

                        break;
                    }
                }
            }
        }
    }

    public void SetNextNoteActive()
    {
        for (int i = 0; i < noteEnabled.Length; i++)
        {
            if (!noteEnabled[i])
            {
                noteEnabled[i] = true;
                enabledDiaryNotes[i] = diaryNotes[i];

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
