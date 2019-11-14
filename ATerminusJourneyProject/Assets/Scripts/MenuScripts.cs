using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour {

    public int charSelect = 0;
    public string sceneToLoad;

    public void setChar(int i) {
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

    public void setScene(string scene) {
        sceneToLoad = scene;
    }

    public void PlayGame() {

        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame () {
        Debug.Log("Sayonara bitches");
        Application.Quit();
    }
}
