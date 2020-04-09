using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public PlayerData playerData;
    public Inventory inventory;
    public string initialScene;
    public GameObject buttonPrefab;
    public GameObject buttonParent;
    public Button buttonLoadGame;
    public int largestSaveNumber = 0;


    private void Start() {
        PopulateSaveList();
    }

    public void PopulateSaveList() {
        List<string> saveFiles = SaveSystem.PopulateSaves();
        bool first = true;
        foreach (string savePath in saveFiles) {
            GameObject button = (GameObject)Instantiate(buttonPrefab);
            string saveName = Path.GetFileNameWithoutExtension(savePath);
            button.GetComponentInChildren<TMP_Text>().SetText(saveName);
            button.transform.SetParent(buttonParent.transform);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, button.transform.localPosition.y, 0);
            button.GetComponent<Button>().onClick.AddListener(delegate { LoadGameFromPath(savePath); });
            if (first) {
                buttonLoadGame.onClick.AddListener(() => button.GetComponent<Button>().Select());
                first = false;
            }
            int saveNum = int.Parse(saveName.Substring(saveName.Length - 3));
            if (saveNum > largestSaveNumber) largestSaveNumber = saveNum;
        }
    }

    public void LoadGameFromPath(string path) {
        PlayerSaveData saveData = SaveSystem.LoadGame(path);
        playerData.LoadPlayerData(saveData);
        inventory.LoadInventory(saveData);
        SceneManager.LoadScene(playerData.currentScene);
    }

    public void SelectSave(Button firstButton) {
        firstButton.Select();
        Debug.Log("ok");
    }

    public void NewGame(string newRole) {
        playerData.NewCharacterData(newRole, largestSaveNumber + 1);
        inventory.NewInventory();
        SceneManager.LoadScene(initialScene.ToString());
    }

    public void QuitGame() {
        Debug.Log("Sayonara bitches");
        Application.Quit();
    }
}
