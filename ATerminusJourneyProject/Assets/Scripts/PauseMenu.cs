using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private bool paused;
    public GameObject pauseMenu;
    public GameObject defaultButton;
    public PlayerController player;
    //I dont know why this is here/what my plans were, so Im just gonna leave it here for now
    public List<GameObject> transitions;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu() {
        paused = !paused;
        pauseMenu.SetActive(paused);
        if (paused) {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
        player.playerState = paused ? PlayerState.inMenu : PlayerState.moving;
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
