using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BackScene : MonoBehaviour
{
    [SerializeField] Button _button;
    static BackScene instance = null;
    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
        _button.onClick.AddListener(BackStartScene);
        SceneManager.sceneLoaded += SceneLoaded;
    }
    void Start() {

    }
    void BackStartScene() {
        if(IsStartScene()) {
            return;
        }
        SceneManager.LoadScene("StartScene");
    }

    bool IsStartScene() {
        return SceneManager.GetActiveScene().name == "StartScene";
    }

    void SceneLoaded(Scene nextScene,LoadSceneMode mode) {
        if(nextScene.name == "StartScene") {
            _button.interactable = false;
        } else {
            _button.interactable = true;
        }
    }


    void OnDestroy() {
        _button.onClick.RemoveListener(BackStartScene);
    }
}
