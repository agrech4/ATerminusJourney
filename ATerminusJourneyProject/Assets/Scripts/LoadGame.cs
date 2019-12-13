using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadGame : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;
    public string fileNameRgx = @"^(save_)[0-9]{3}$";
    public string fileDir = @"C:\Users\Grechinitus\Documents\SavedGames\ATerminusJourney";
    private List<string> saveFilePaths;
    private List<string> saveFiles;
    public Regex rgx;

    public void OnEnable() {
        rgx = new Regex(fileNameRgx);
        saveFilePaths = new List<string>();
        saveFiles = new List<string>();

        if (Directory.Exists(fileDir)) {
            foreach (string dir in Directory.GetFiles(fileDir)) {
                string fileName = Path.GetFileNameWithoutExtension(dir);
                string fileDir = dir;
                if (rgx.IsMatch(fileName)) {
                    saveFiles.Add(fileName);
                    saveFilePaths.Add(fileDir);
                    CreateButtonOption(fileName);
                }
            }
            buttonParent.transform.GetChild(0).GetComponent<Button>().Select();
        }
    }

    public void OnDisable() {
        foreach (Transform child in buttonParent.transform) {
            Destroy(child.gameObject);
        }
    }

    private void CreateButtonOption(string fileDir) {
        GameObject buttonObj = (GameObject)Instantiate(buttonPrefab);
        buttonObj.GetComponentInChildren<TMP_Text>().SetText(fileDir);
        buttonObj.transform.parent = buttonParent.transform;
        buttonObj.transform.localScale = new Vector3(1, 1, 1);
        buttonObj.transform.localPosition = new Vector3(buttonObj.transform.localPosition.x, buttonObj.transform.localPosition.y, 0);
    }
}
