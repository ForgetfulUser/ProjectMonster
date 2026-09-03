using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterLoader : MonoBehaviour
{
    public static MonsterLoader Instance;


    [Header("Temp Monster Settings")]
    public Sprite Sprite;
    public string Name = "Monster";
    [TextArea]
    public string Description;
    public Vector2Int Health;
    public int PhysicalAttack;
    public int MagicalAttack;
    public int PhysicalDefense;
    public int MagicalDefense;
    public int Speed;

    private void Awake()
    {
        Instance = this;
    }

    public void TempSave()
    {
        string filePath = Application.dataPath + "/Monster Files/Monster.txt";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        MonsterData monster = new MonsterData
        {
            Sprite = Sprite,
            Name = Name,
            Description = Description,
            Health = Health,
            PhysicalAttack = PhysicalAttack,
            MagicalAttack = MagicalAttack,
            PhysicalDefense = PhysicalDefense,
            Speed = Speed,
        };

        string json = JsonUtility.ToJson(monster);
        File.WriteAllText(filePath, json);
    }

    public static void SaveMonster(MonsterData monsterToSave)
    {
        string filePath = Application.dataPath + "/Monster Files/" + monsterToSave.Name + ".txt";
        string json = JsonUtility.ToJson(monsterToSave);
        File.WriteAllText(filePath, json);
    }

    public static void LoadMonster(string name)
    {
        string monsterFilePath = Application.dataPath + "/Monster Files/" + name + ".txt"; // Load monster file path by name

        if (File.Exists(monsterFilePath)) // Check file path
        {
            string monsterStr = File.ReadAllText(monsterFilePath); 
            MonsterData monster = JsonUtility.FromJson<MonsterData>(monsterStr);
        }
        else
        {
            Debug.Log("FILE NOT FOUND");
        }
    }

    public static List<MonsterData> LoadAllMonsterDatas(string path)
    {
        // The master list that collects all individual JSON file items
        List<MonsterData> allItemsList = new List<MonsterData>();

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
            Debug.Log(filePath);
            try
            {
                // Read the plain text content from the file
                string jsonText = File.ReadAllText(filePath);

                // Deserialize the text into a single ItemData object
                MonsterData data = JsonUtility.FromJson<MonsterData>(jsonText);

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
