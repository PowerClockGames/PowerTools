using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteRendererExtension
{
    public static void FadeIn(this SpriteRenderer renderer, MonoBehaviour mono, float duration, System.Action<SpriteRenderer> callback = null)
    {
        mono.StartCoroutine(FadeInCoroutine(renderer, duration, callback));
    }

    public static void FadeOut(this SpriteRenderer renderer, MonoBehaviour mono, float duration, System.Action<SpriteRenderer> callback = null)
    {
        mono.StartCoroutine(FadeOutCoroutine(renderer, duration, callback));
    }

    private static IEnumerator FadeInCoroutine(SpriteRenderer renderer, float duration, System.Action<SpriteRenderer> callback)
    {
        // Fading animation
        float start = Time.time;
        while (Time.time <= start + duration)
        {
            Color color = renderer.color;
            color.a = 0f + Mathf.Clamp01((Time.time - start) / duration);
            renderer.color = color;
            yield return new WaitForEndOfFrame();
        }

        // Callback
        if (callback != null)
            callback(renderer);
    }

    private static IEnumerator FadeOutCoroutine(SpriteRenderer renderer, float duration, System.Action<SpriteRenderer> callback)
    {
        // Fading animation
        float start = Time.time;
        while (Time.time <= start + duration)
        {
            Color color = renderer.color;
            color.a = 1f - Mathf.Clamp01((Time.time - start) / duration);
            renderer.color = color;
            yield return new WaitForEndOfFrame();
        }

        // Callback
        if (callback != null)
            callback(renderer);
    }
}
