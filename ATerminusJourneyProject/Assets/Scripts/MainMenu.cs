using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public PlayerData playerData;
    public string sceneToLoad;


    private void Start() {

    }

    public void Update() {

    }

    public void SetAnimator(RuntimeAnimatorController animator) {
        playerData.animatorController = animator;
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
