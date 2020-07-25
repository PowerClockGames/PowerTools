using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ImageExtension
{
    public static void FadeIn(this Image img, MonoBehaviour mono, float duration, System.Action<Image> callback = null)
    {
        mono.StartCoroutine(FadeInCoroutine(img, duration, callback));
    }

    public static void FadeOut(this Image img, MonoBehaviour mono, float duration, System.Action<Image> callback = null)
    {
        mono.StartCoroutine(FadeOutCoroutine(img, duration, callback));
    }

    private static IEnumerator FadeInCoroutine(Image img, float duration, System.Action<Image> callback)
    {
        // Fading animation
        float start = Time.time;
        while (Time.time <= start + duration)
        {
            Color color = img.color;
            color.a = 0f + Mathf.Clamp01((Time.time - start) / duration);
            img.color = color;
            yield return new WaitForEndOfFrame();
        }

        // Callback
        if (callback != null)
            callback(img);
    }

    private static IEnumerator FadeOutCoroutine(Image img, float duration, System.Action<Image> callback)
    {
        // Fading animation
        float start = Time.time;
        while (Time.time <= start + duration)
        {
            Color color = img.color;
            color.a = 1f - Mathf.Clamp01((Time.time - start) / duration);
            img.color = color;
            yield return new WaitForEndOfFrame();
        }

        // Callback
        if (callback != null)
            callback(img);
    }
}
