using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IFadeInImage 
{
    IEnumerator FadeIn();

    IEnumerator FadeOut();
}
