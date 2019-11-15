using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string sceneToLoad;
    private bool playerCollision;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(playerCollision && Input.GetButtonUp("Submit")) {
            loadScene();
        }
        
    }

    public void setScene(string scene) {
        sceneToLoad = scene;
    }
    
    private void loadScene() {
        SceneManager.LoadScene(sceneToLoad);
    }


    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerCollision = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerCollision = false;
        }
    }
}
