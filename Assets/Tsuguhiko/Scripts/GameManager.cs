using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance;

    ResearchObjectManager _researchObjectManager;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    

    private GameManager()
    {
        
        // Initialize in constructor
        // ex: loading game data, etc.
        LoadGameData();
    }

    private void LoadGameData()
    {
        // Loading game data
        // Change the data loading way as to your project requirements.

        // GetComponnent the game object that ResearchObjectManager has.
        // (It's not very good coding, so please fix it if you can.)
        _researchObjectManager = GameObject.Find("EmptyObject").GetComponent<ResearchObjectManager>();

        _researchObjectManager.ResearchObjects[0].SetActive(true);
        _researchObjectManager.ResearchObjects[1].SetActive(false);
        _researchObjectManager.ResearchObjects[2].SetActive(false);
       
    }


    // Call from anywhere
    public void MyFunction()
    {
        Debug.Log("Function called from GameManager");
    }
}
