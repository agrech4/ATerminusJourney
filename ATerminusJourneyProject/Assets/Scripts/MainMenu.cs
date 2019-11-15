using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public int charSelect = 0;
    public string sceneToLoad;

    private void Start() {

    }

    public void Update() {

    }

    public void SetChar(int i) {
        charSelect = i;
        switch (charSelect) {
            case 0:
                Debug.Log("Barbarian");
                break;
            case 1:
                Debug.Log("Druid");
                break;
        }
    }

    public void SetScene(string scene) {
        sceneToLoad = scene;
    }

    public void PlayGame() {

        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame() {
        Debug.Log("Sayonara bitches");
        Application.Quit();
    }
}
