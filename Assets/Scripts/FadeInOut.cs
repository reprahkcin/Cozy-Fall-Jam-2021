using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    // Singleton
    public static FadeInOut instance;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Black Image
    public Image blackImage;

    // Fade In
    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    // Fade Out
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }

    // Fade In Routine
    IEnumerator FadeInRoutine()
    {
        float alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime / 2;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    // Fade Out Routine
    IEnumerator FadeOutRoutine()
    {
        float alpha = 1;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime / 2;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

}
