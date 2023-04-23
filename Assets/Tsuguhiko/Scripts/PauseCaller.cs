using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseCaller : MonoBehaviour
{
    // [SerializeField] private TMP_Text _pauseText;
    [SerializeField] private GameObject _pausePanel;
    

    private void Start()
    {
        PauseManager.Initialize(EventSystem.current, _pausePanel); 
    }

    private void Update()
    {
        PauseManager.Update();
    }

    
}
