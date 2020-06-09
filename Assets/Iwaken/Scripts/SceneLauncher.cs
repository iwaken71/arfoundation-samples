using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneLauncher : MonoBehaviour
{
    [SerializeField] MoveSceneButton buttonPrefab;
    [SerializeField] Transform contentParent;

    [SerializeField] public string[] sceneNameList;

    void Start()
    {
#if UNITY_EDITOR
        SetUpSceneName();
#endif
        foreach(var name in sceneNameList) {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(contentParent);
            button.Initialize(name);
        }
    }
#if UNITY_EDITOR
    [MenuItem ("Iwaken/SetUpSceneName")]
    void SetUpSceneName() {
        sceneNameList = EditorBuildSettings.scenes
                        .Where(scene => scene.enabled)
                        .Select(scene => scene.path).ToArray();
    }
#endif
}
