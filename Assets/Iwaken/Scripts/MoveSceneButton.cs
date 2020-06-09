using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class MoveSceneButton : MonoBehaviour
{
    string scenePath;

    Button _button;

    [SerializeField] Text _text;

    void Awake() {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClickButton);
    }
    void OnClickButton() {
        SceneManager.LoadScene(scenePath);
    }

    public void Initialize(string scenePath) {
        this.scenePath = scenePath;
        _text.text = scenePath;
    }

    void OnDestroy() {

        _button.onClick.RemoveListener(OnClickButton);
    }
}
