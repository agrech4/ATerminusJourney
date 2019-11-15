using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public Button defaultButton;
    public PlayerController player;
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
        pauseMenu.SetActive(!paused);
        if (!paused) {
            defaultButton.FindSelectableOnDown().Select();
            defaultButton.Select();
        }
        player.playerState = paused? PlayerState.moving : PlayerState.inMenu;
        paused = !paused;
    }
}
