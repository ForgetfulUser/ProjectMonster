using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AbilityLoader
{
    public static string AbilityDataPath = Application.dataPath + "/StreamingAssets/Ability Data/";

    public static void SaveAbility(AbilityData abilityToSave)
    {
        string filePath = AbilityDataPath + abilityToSave.Name + ".txt";
        
        string json = JsonUtility.ToJson(abilityToSave);
        File.WriteAllText(filePath, json);
    }

    public static AbilityData LoadAbilityByName(string name)
    {
        string monsterFilePath = AbilityDataPath + name + ".txt"; // Generate path for monster data

        return LoadAbilityByPath(monsterFilePath);
    }

    public static AbilityData LoadAbilityByPath(string path)
    {
        AbilityData Ability;
        if (File.Exists(path)) // Check file path
        {
            string monsterStr = File.ReadAllText(path);
            Ability = JsonUtility.FromJson<AbilityData>(monsterStr);
            Ability.LoadAbility();
            string spritePath = "Sprites/Monsters/" + Ability.Name;
            Ability.Sprite = Resources.Load<Sprite>(spritePath);
        }
        else
        {
            Ability = new AbilityData();
            Debug.Log("FILE NOT FOUND");
        }

        return Ability;
    }

    public static List<AbilityData> LoadAllAbilityDatas()
    {
        string path = AbilityDataPath;
        // The master list that collects all individual JSON file items
        List<AbilityData> allItemsList = new List<AbilityData>();

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
                AbilityData data = LoadAbilityByPath(filePath);

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

    public static List<AbilityData> LoadAllAbilityDatasByRarity(RarityType rarity)
    {
        string path = AbilityDataPath;
        // The master list that collects all individual JSON file items
        List<AbilityData> allItemsList = new List<AbilityData>();

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
                AbilityData data = LoadAbilityByPath(filePath);

                // Add the populated object to your main tracking list
                if (data != null && data.MonsterRarity <= rarity)
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

    public static void DeleteAbility(string name)
    {
        string path = AbilityDataPath + name + ".txt";
        File.Delete(path);
    }

}
