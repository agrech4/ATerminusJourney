using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    static string directory = Application.persistentDataPath + "/Saves";
    static string fileName = "/Save";
    static string fileExtension = ".json";

    public static void SaveGame(PlayerData data) {
        PlayerSaveData dataToStore = new PlayerSaveData(data);
        //string fileName = data.charName;
        string path = directory + fileName + fileExtension;
        if (!Directory.Exists(directory)) {
            Directory.CreateDirectory(directory);
        }
        DataContractJsonSerializer cereal = new DataContractJsonSerializer(typeof(PlayerSaveData));
        //BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = File.Create(path)) {
            cereal.WriteObject(fs, dataToStore);
            //formatter.Serialize(fs, dataToStore);
        }
    }

    public static void LoadGame() {
        PlayerSaveData dataToLoad;
        string path = directory + fileName + fileExtension;
        DataContractJsonSerializer cereal = new DataContractJsonSerializer(typeof(PlayerSaveData));
        if (File.Exists(path)) {
            using (FileStream fs = File.OpenRead(path)) {
                dataToLoad = cereal.ReadObject(fs) as PlayerSaveData;
            }
            Debug.Log(dataToLoad.expToNextLvl);
        } else {
            Debug.LogError("Failed to load file at " + path);
        }
    }
}
