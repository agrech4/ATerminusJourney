using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string sceneToLoad;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void setScene(string scene) {
        sceneToLoad = scene;
    }
    
    private void loadScene() {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnTriggerStay2D(Collider2D other) {
        float enter = Input.GetAxis("Submit");
        if (other.CompareTag("Player") && (enter > 0) ) {
            loadScene();
        }
    }
}
