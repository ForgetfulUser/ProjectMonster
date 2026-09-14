using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class BuffLoader : MonoBehaviour
{
    public static BuffLoader Instance;
    public static string BuffDataPath = Application.dataPath + "/StreamingAssets/Buff Data/";

    private void Awake()
    {
        Instance = this;
    }

    public static void SaveBuff(BuffData buffToSave)
    {
        string filePath = BuffDataPath + buffToSave.Name + ".txt";
        string json = JsonUtility.ToJson(buffToSave);
        File.WriteAllText(filePath, json);
    }

    public static BuffData LoadBuffByName(string name)
    {
        string buffFilePath = BuffDataPath + name + ".txt"; // Generate path for monster data

        return LoadBuffByPath(buffFilePath);
    }

    public static BuffData LoadBuffByPath(string path)
    {
        BuffData buff;
        if (File.Exists(path)) // Check file path
        {
            string monsterStr = File.ReadAllText(path);
            buff = JsonUtility.FromJson<BuffData>(monsterStr);
            string spritePath = "Sprites/Monsters/" + buff.Name;
            buff.Sprite = Resources.Load<Sprite>(spritePath);
        }
        else
        {
            buff = new BuffData();
            Debug.Log("FILE NOT FOUND");
        }

        return buff;
    }

    public static List<BuffData> LoadAllBuffDatas(string path)
    {
        // The master list that collects all individual JSON file items
        List<BuffData> allItemsList = new List<BuffData>();

        // Ensure the directory actually exists before trying to read it
        if (!Directory.Exists(path))
        {
            Debug.LogError($"Directory not found at: {path}");
            return null;
        }

        // Get all files matching the .json extension inside the folder
        string[] filePaths = Directory.GetFiles(path, "*.txt");

        foreach (string filePath in filePaths)
        {
            try
            {
                // Read the plain text content from the file
                string jsonText = File.ReadAllText(filePath);

                // Deserialize the text into a single ItemData object
                BuffData data = LoadBuffByPath(filePath);

                // Add the populated object to your main tracking list
                if (data != null)
                {
                    allItemsList.Add(data);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to parse file at {filePath}. Error: {e.Message}");
            }
        }
        Debug.Log($"Successfully loaded {allItemsList.Count} JSON files into the list.");
        return allItemsList;
    }
}
