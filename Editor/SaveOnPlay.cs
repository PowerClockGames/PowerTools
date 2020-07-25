using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class SaveOnPlay
{
    static SaveOnPlay()
    {
        EditorApplication.playModeStateChanged += SaveCurrentScene;
    }

    static void SaveCurrentScene(PlayModeStateChange change)
    {
        if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode && change == PlayModeStateChange.EnteredPlayMode)
        {
#if UNITY_5_3
            Debug.Log("Saving open scenes on play...");
            UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
#else
            Debug.Log("Saving scene on play...");
            EditorSceneManager.SaveOpenScenes();
#endif
        }
    }
}