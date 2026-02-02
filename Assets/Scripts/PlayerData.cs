using System;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [System.Serializable]
    private class PlayerSaveData
    {
        public int health;
        public float progress;
        public int coins;
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void CreatePlayerSaveFile()
    {
        string savesFolderPath = Path.Combine(Application.persistentDataPath, "Saves");
        Directory.CreateDirectory(savesFolderPath);
        // build full file
        string saveFilePath = Path.Combine(savesFolderPath, "save1.json");
        
        // write json
        PlayerSaveData dataToSave = new PlayerSaveData();
        dataToSave.health = 60;
        dataToSave.progress = 20.5f;
        dataToSave.coins = 10;

        string json = JsonUtility.ToJson(dataToSave, true);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("Saved file to: " + saveFilePath);
        Debug.Log("Saved JSON:\n" + json);

        // read json
        if (File.Exists(saveFilePath))
        {
            string loadedJson = File.ReadAllText(saveFilePath);
            PlayerSaveData loadedData = JsonUtility.FromJson<PlayerSaveData>(loadedJson);

            Debug.Log("Loaded health: " + loadedData.health);
            Debug.Log("Loaded coins: " + loadedData.coins);
            Debug.Log("Loaded progress: " + loadedData.progress);
        }

    }
}
