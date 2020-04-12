using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EncounterMenu : MonoBehaviour {

    public Animator animator;
    public PlayerData playerData;
    public TMP_Text playerName;
    public GameObject selectedButton;
    public PlayerController player;
    public GameObject pauseMenu;
    public GameObject encounterMenu;
    private bool activeMenu = false;



    // Start is called before the first frame update
    void Start() { 
        playerName.text = playerData.charName;
    }



    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Menu") && !pauseMenu.activeInHierarchy) {
            ToggleMenu();
        }
    }

    public void SetActiveButton() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectedButton);
    }

    void ToggleMenu() {
        activeMenu = !activeMenu;
        animator.SetBool("activeMenu", activeMenu);
        if (!activeMenu) {
            selectedButton = EventSystem.current.currentSelectedGameObject;
            EventSystem.current.SetSelectedGameObject(null);
        } else {
            StartCoroutine(WaitForActiveMenu());
        }
        player.playerState = activeMenu ? PlayerState.inMenu : PlayerState.moving;
    }

    private IEnumerator WaitForActiveMenu() {
        yield return new WaitUntil(() => encounterMenu.activeInHierarchy);
        SetActiveButton();
    }

    public void Movement() {
        ((PlayerControllerEncounter)player).SetMovableTiles(playerData.MovementInTiles());
        ToggleMenu();
    }
}
