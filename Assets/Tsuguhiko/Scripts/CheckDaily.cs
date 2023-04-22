using UnityEngine;

/// <summary>
/// This script is Date can look see on Inspector.
/// </summary>

public class CheckDaily : MonoBehaviour
{
    [SerializeField,Header("Date")] DailyChapter _dailyChapter;
    void Start()
    {
         Debug.Log(_dailyChapter.ToString());
    }

}
