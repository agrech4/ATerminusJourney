using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using UnityEngine;

public static class SaveSystem
{

    static string directory = Application.persistentDataPath + "/Saves/";
    static string fileExtension = ".json";
    static string rgxFileName = @"^[sS]ave\d+.[jJ][sS][oO][nN]$";

    public static void SaveGame(PlayerData data) {
        PlayerSaveData dataToStore = new PlayerSaveData(data);
        string path = directory + dataToStore.saveName + fileExtension;
        if (!Directory.Exists(directory)) {
            Directory.CreateDirectory(directory);
        }
        DataContractJsonSerializer cereal = new DataContractJsonSerializer(typeof(PlayerSaveData));
        //BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = File.Create(path)) {
            cereal.WriteObject(fs, dataToStore);
            //formatter.Serialize(fs, dataToStore);
            Debug.Log("Game Saved.");
        }
        
    }

    public static PlayerSaveData LoadGame(string path) {
        PlayerSaveData dataToLoad;
        DataContractJsonSerializer cereal = new DataContractJsonSerializer(typeof(PlayerSaveData));
        if (File.Exists(path)) {
            using (FileStream fs = File.OpenRead(path)) {
                dataToLoad = cereal.ReadObject(fs) as PlayerSaveData;
            }
            return dataToLoad;
        } else {
            Debug.LogError("Failed to load file at " + path);
            return null;
        }
        
    }

    public static List<string> PopulateSaves() {
        Regex rgx = new Regex(rgxFileName);
        if (!Directory.Exists(directory)) {
            Directory.CreateDirectory(directory);
        }
        string[] allFiles = Directory.GetFiles(directory);
        List<string> saveFiles = new List<string>();
        foreach (string path in allFiles) {
            if (rgx.IsMatch(Path.GetFileName(path))) {
                saveFiles.Add(path);
            }
        }
        return saveFiles;
    }
}
