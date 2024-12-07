using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
   
    [SerializeField] Image fadeImage;
    [SerializeField] Color fadeColor = Color.black;
    [SerializeField] float fadeTime = 0.5f;

    bool fading = false;

    public void FadeToColor()
    {
        
        if(fading)
        {
            return;
        }
        fading = true;
        
        StartCoroutine(FadeToColorRoutine());

        IEnumerator FadeToColorRoutine()
        {
            float t = 0;

            while(t<fadeTime)
            {
                yield return null;
                t+=Time.deltaTime;
                fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, t/fadeTime);
            }

            fadeImage.color = fadeColor;
            fading = false;
            yield return null;
        }
    }
}
