using System.Collections;

namespace UnityEngine
{
    public static class FadeAudio
    {
        public static void FadeOut(this AudioSource a, float duration)
        {
            a.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCore(a, duration));
        }

        public static void FadeIn(this AudioSource a, float duration)
        {
            a.GetComponent<MonoBehaviour>().StartCoroutine(FadeInCore(a, duration));
        }

        public static void FadeOutCallback(this AudioSource a, float duration, System.Action<AudioSource> callback = null)
        {
            a.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCall(a, duration, callback));
        }

        public static void FadeInCallback(this AudioSource a, float duration, System.Action<AudioSource> callback = null)
        {
            a.GetComponent<MonoBehaviour>().StartCoroutine(FadeInCall(a, duration, callback));
        }

        private static IEnumerator FadeOutCore(AudioSource a, float duration)
        {
            float startVolume = a.volume;

            while (a.volume > 0)
            {
                a.volume -= startVolume * Time.deltaTime / duration;
                yield return new WaitForEndOfFrame();
            }

            a.Stop();
            a.volume = startVolume;
        }

        public static IEnumerator FadeInCore(AudioSource a, float duration)
        {
            float startVolume = 0.2f;

            a.volume = 0;
            a.Play();

            while (a.volume < 1.0f)
            {
                a.volume += startVolume * Time.deltaTime / duration;

                yield return null;
            }

            a.volume = 1f;
        }

        private static IEnumerator FadeOutCall(AudioSource a, float duration, System.Action<AudioSource> callback)
        {
            float startVolume = a.volume;

            while (a.volume > 0)
            {
                a.volume -= startVolume * Time.deltaTime / duration;
                yield return new WaitForEndOfFrame();
            }

            a.Stop();
            a.volume = startVolume;

            // Callback
            if (callback != null)
                callback(a);
        }

        public static IEnumerator FadeInCall(AudioSource a, float duration, System.Action<AudioSource> callback)
        {
            float startVolume = 0.2f;

            a.volume = 0;
            a.Play();

            while (a.volume < 1.0f)
            {
                a.volume += startVolume * Time.deltaTime / duration;

                yield return null;
            }

            a.volume = 1f;

            // Callback
            if (callback != null)
                callback(a);
        }
    }
}

