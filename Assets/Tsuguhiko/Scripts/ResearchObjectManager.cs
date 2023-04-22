using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchObjectManager : MonoBehaviour
{
    public delegate void ItemClicked();
    public static event ItemClicked itemClicked;

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
        for (int i = 0; i < _researchObjects.Length; i++)
        {
            if (_researchObjects[i].gameObject.activeSelf && !_isClicked[i])
            {
                _isClicked[i] = true;
                itemClicked?.Invoke();
            }
        }

        //if (_researchObjects[0] && _isClicked[0] == false)
        //{
        //    _isClicked[0] = true;
        //}
    }
}
