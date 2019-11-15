using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string sceneToLoad;
    private bool playerInRange;
    public PlayerController player;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (playerInRange && Input.GetButtonDown("Interact") 
            && player.playerState != PlayerState.inMenu) {
            LoadScene();
        }
    }

    public void SetScene(string scene) {
        sceneToLoad = scene;
    }

    private void LoadScene() {
        SceneManager.LoadScene(sceneToLoad);
    }


    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
        }
    }
}
