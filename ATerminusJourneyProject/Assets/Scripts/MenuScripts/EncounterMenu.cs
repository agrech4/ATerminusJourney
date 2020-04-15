using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class EncounterMenu : MonoBehaviour {

    public Animator animator;
    public PlayerData playerData;
    public TMP_Text playerName;
    public GameObject selectedButton;
    public Button movementButton;
    public PlayerControllerEncounter player;
    public GameObject pauseMenu;
    public GameObject encounterMenu;
    public GameObject movementOverlay;
    private bool menuActive = false;
    private bool movementActive = false;
    private int movement;



    // Start is called before the first frame update
    void Start() { 
        playerName.text = playerData.charName;
        movement = playerData.MovementInTiles();
        if (movement <= 0) {
            movementButton.interactable = false;
        } else {
            movementButton.interactable = true;
        }
    }



    // Update is called once per frame
    void Update() {
        if (!pauseMenu.activeInHierarchy) {
            if (Input.GetButtonDown("Menu") || (movementActive && !menuActive && Input.GetButtonDown("Submit"))) {
                ToggleMenu();
            }
        }
    }

    public void SetActiveButton() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectedButton);
    }

    void ToggleMenu() {
        menuActive = !menuActive;
        animator.SetBool("activeMenu", menuActive);
        movementOverlay.SetActive(!menuActive);
        if (!menuActive) {
            selectedButton = EventSystem.current.currentSelectedGameObject;
            EventSystem.current.SetSelectedGameObject(null);
        } else {
            StartCoroutine(WaitForActiveMenu());
        }
        player.playerState = menuActive ? PlayerState.inMenu : PlayerState.moving;
    }

    private IEnumerator WaitForActiveMenu() {
        yield return new WaitUntil(() => encounterMenu.activeInHierarchy);
        SetActiveButton();
    }

    public void Movement() {
        if (!movementActive) {
            player.SetMovableTiles(movement);
            player.DisplayMovableTiles();
            movementActive = true;
        }
        StartCoroutine(ToggleMenuAtEndOfFrame());
    }

    private IEnumerator ToggleMenuAtEndOfFrame  () {
        yield return new WaitForEndOfFrame();
        ToggleMenu();
    }

    public void ConfirmMovement() {
        movementActive = false;
        movement -= player.GetDistMoved();
        if (movement <= 0) {
            movementButton.interactable = false;
        }
        player.ResetMovableTiles();
    }

    public void EndTurn() {
        if (movementActive) ConfirmMovement();
        movement = playerData.MovementInTiles();
        if (movement <= 0) {
            movementButton.interactable = false;
        } else {
            movementButton.interactable = true;
        }
    }
}
