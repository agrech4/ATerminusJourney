using System;
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
    public List<ScriptableObject> toSave;

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

    public void LoadGame() {

    }

    public void SaveGame() {
        SaveSystem.SaveGame(toSave[0] as PlayerData);
        //string dir = Application.persistentDataPath;
        //string fileName = @"Save";
        //string fileExtension = @".json";
        //string path = dir + fileName + fileExtension;
        //if (!Directory.Exists(dir)) {
        //    Directory.CreateDirectory(dir);
        //}
        //Debug.Log(path);
        //using (FileStream fs = File.Create(path)) {
        //    byte[] info = new UTF8Encoding(true).GetBytes("foook");
        //    fs.Write(info, 0, info.Length);
        //}
    }
}
