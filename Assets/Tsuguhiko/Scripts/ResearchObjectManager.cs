using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchObjectManager : MonoBehaviour
{
    [SerializeField] GameObject[] _researchObjects;

    [SerializeField] bool[] _isClicked;

    public GameObject[] ResearchObjects 
    {
        get { return _researchObjects; }
        set { _researchObjects = value; } 
    }

    public bool[] IsClicked
    {
        get { return _isClicked; }
        set { _isClicked = value; }
    }

    void Start()
    {
        GameManager.Instance.MyFunction();
    }
    public void OnClickEvent()
    {
        if (_researchObjects[0] && _isClicked[0] == false)
        {
            _isClicked[0] = true;
        }
    }
}
