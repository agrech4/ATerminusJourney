using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public Button defaultButton;
    public PlayerController playerController;
    public List<GameObject> transitions;
    public bool paused;

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
        if (!paused) {
            pauseMenu.SetActive(true);
            defaultButton.FindSelectableOnDown().Select();
            defaultButton.Select();
            playerController.enabled = false;
            foreach (GameObject transition in transitions) {
                transition.SetActive(false);
            }
            paused = true;
        } else {
            pauseMenu.SetActive(false);
            playerController.enabled = true;
            foreach (GameObject transition in transitions) {
                transition.SetActive(true);
            }
            paused = false;
        }
    }
}
