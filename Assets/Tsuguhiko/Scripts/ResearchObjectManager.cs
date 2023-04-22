using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class ResearchObjectManager : MonoBehaviour
{
    public delegate void ItemClicked();
    public static event ItemClicked itemClicked;

    [SerializeField] GameObject[] _researchObjects;

    Button[] _searchImageButton;
    GameObject[] _panelImage;
    GameObject[] _activatedImage;

    [SerializeField] bool[] _isClicked;

    private void Start()
    {
        _searchImageButton = new Button[7];
        _panelImage = new GameObject[7];
        _activatedImage = new GameObject[7];
    }

    public GameObject[] ResearchObjects
    {
        get { return _researchObjects; }
        set { _researchObjects = value; }
    }

    //public bool[] IsClicked
    //{
    //    get { return _isClicked; }
    //    set { _isClicked = value; }
    //}

    //void Start()
    //{
    //    GameManager.Instance.MyFunction();
    //}

    public void OnClickEvent()
    {
        for (int i = 0; i < _researchObjects.Length; i++)
        {
            if (_researchObjects[i].gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                if ((i + 1) <= _researchObjects.Length)
                {
                    SetNextActiveObject();
                    itemClicked?.Invoke();
                    break;
                }
                else
                {
                    _searchImageButton[i] = _researchObjects[i].gameObject.GetComponent<Button>();
                    _panelImage[i] = _researchObjects[i].gameObject.transform.GetChild(1).gameObject;
                    _activatedImage[i] = _researchObjects[i].gameObject.transform.GetChild(2).gameObject;

                    _searchImageButton[i].interactable = false;
                    _panelImage[i].SetActive(false);
                    _activatedImage[i].gameObject.GetComponent<Image>().DOFade(1, 2f);

                    itemClicked?.Invoke();
                }
            }
        }

        //if (_researchObjects[0] && _isClicked[0] == false)
        //{
        //    _isClicked[0] = true;
        //}
    }

    private void SetNextActiveObject()
    {
        for (int i = 0; i < _researchObjects.Length; i++)
        {
            if (_researchObjects[i].gameObject.transform.GetChild(1).gameObject.activeSelf)
            {
                _searchImageButton[i] = _researchObjects[i].gameObject.GetComponent<Button>();
                _panelImage[i] = _researchObjects[i].gameObject.transform.GetChild(1).gameObject;
                _activatedImage[i] = _researchObjects[i].gameObject.transform.GetChild(2).gameObject;

                _searchImageButton[i].interactable = false;
                _panelImage[i].SetActive(false);
                _activatedImage[i].gameObject.GetComponent<Image>().DOFade(1, 2f);

                if ((i + 1) < _researchObjects.Length)
                {
                    _searchImageButton[i + 1] = _researchObjects[i + 1].gameObject.GetComponent<Button>();
                    _panelImage[i + 1] = _researchObjects[i + 1].gameObject.transform.GetChild(1).gameObject;
                    
                    _researchObjects[i + 1].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    _searchImageButton[i + 1].interactable = true;
                }

                break;
            }
        }
    }
}
