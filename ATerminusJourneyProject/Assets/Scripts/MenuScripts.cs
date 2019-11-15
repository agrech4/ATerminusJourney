using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour {

    public int charSelect = 0;
    public string sceneToLoad;
    public GameObject pauseMenu;
    public Button defaultButton;
    public GameObject player;
    public List<GameObject> transitions;

    private void Start() {
    }

    public void Update() {
        if (Input.GetButtonUp("Cancel")) {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu(string button) {
        StartCoroutine(WaitForButtonRelease(button));
    }

    public void TogglePauseMenu() {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        if (pauseMenu.activeInHierarchy) {
            defaultButton.FindSelectableOnDown().Select();
            defaultButton.Select();
        }
        player.GetComponent<PlayerController>().enabled = !player.GetComponent<PlayerController>().enabled;
        foreach (GameObject transition in transitions) {
            transition.SetActive(!transition.activeInHierarchy);
        }
    }

    public IEnumerator WaitForButtonRelease(string button) {
        yield return new WaitUntil(() => Input.GetButtonUp(button));
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        player.GetComponent<PlayerController>().enabled = !player.GetComponent<PlayerController>().enabled;
        foreach (GameObject transition in transitions) {
            transition.SetActive(!transition.activeInHierarchy);
        }
    }

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
