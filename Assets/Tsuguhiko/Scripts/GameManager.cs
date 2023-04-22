using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager
{
    private static GameManager _instance;

    ResearchObjectManager _researchObjectManager;

    IFadeInImage _fadeImage;

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
        LoadGameData();
    }

    public void MyFunction()
    {
        Debug.Log("Function called from GameManager");
    }

    private void LoadGameData()
    {
        _fadeImage = GameObject.Find("FadeImage").GetComponent<IFadeInImage>();
        _researchObjectManager = GameObject.Find("EmptyObject").GetComponent<ResearchObjectManager>();

        _researchObjectManager.ResearchObjects[0].SetActive(true);
        _researchObjectManager.ResearchObjects[1].SetActive(false);
        _researchObjectManager.ResearchObjects[2].SetActive(false);

    }
}
