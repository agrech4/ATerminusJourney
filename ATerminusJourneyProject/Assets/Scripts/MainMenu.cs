using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public PlayerData playerData;
    public string sceneToLoad;
    public GameObject buttonPrefab;
    public GameObject buttonParent;
    public Button buttonLoadGame;


    private void Start() {
        PopulateSaveList();
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

    public void PopulateSaveList() {
        List<string> saveFiles = SaveSystem.PopulateSaves();
        bool first = true;
        foreach (string savePath in saveFiles) {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponentInChildren<TMP_Text>().SetText(Path.GetFileNameWithoutExtension(savePath));
            button.transform.SetParent(buttonParent.transform);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, button.transform.localPosition.y, 0);
            button.GetComponent<Button>().onClick.AddListener(delegate { LoadGameFromPath(savePath); });
            if (first) {
                buttonLoadGame.onClick.AddListener( () => button.GetComponent<Button>().Select() );
                first = false;
            }
        }

    }

    public void LoadGameFromPath(string path) {
        playerData.loadData(SaveSystem.LoadGame(path));
        Debug.Log(playerData.purse.ep);
        SceneManager.LoadScene(playerData.currentScene);
    }

    public void SelectSave(Button firstButton) {
        firstButton.Select();
        Debug.Log("ok");
    }

    public void QuitGame() {
        Debug.Log("Sayonara bitches");
        Application.Quit();
    }
}
