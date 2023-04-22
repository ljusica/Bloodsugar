using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImageMono : MonoBehaviour, IFadeInImage
{
    [SerializeField] Image _imageToFade;
    [SerializeField] float _fadeInDuration = 2.0f;
    [SerializeField] GameObject _fadeObject;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Color imageColor = _imageToFade.color;
        byte byteAlpha = 255;
        imageColor.a = byteAlpha / 255f;
        _imageToFade.color = imageColor;

        float elapsedTime = 0;
        while (elapsedTime < _fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            byteAlpha = (byte)(255 - Mathf.Clamp((int)(elapsedTime / _fadeInDuration * 255), 0, 255));
            imageColor.a = byteAlpha / 255f;
            _imageToFade.color = imageColor;
            yield return null;
        }

        byteAlpha = 0;
        imageColor.a = byteAlpha / 255f;
        _imageToFade.color = imageColor;
        _fadeObject.SetActive(false);
    }
}
