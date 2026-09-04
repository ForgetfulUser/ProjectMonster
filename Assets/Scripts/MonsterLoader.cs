using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterLoader : MonoBehaviour
{
    public static MonsterLoader Instance;
    public static string MonsterDataPath = Application.dataPath + "/StreamingAssets/Monster Data/";

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
        string filePath = MonsterDataPath + "Monster.txt";
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
        string filePath = MonsterDataPath + monsterToSave.Name + ".txt";
        string json = JsonUtility.ToJson(monsterToSave);
        File.WriteAllText(filePath, json);
    }

    public static MonsterData LoadMonsterByName(string name)
    {
        string monsterFilePath = MonsterDataPath + name + ".txt"; // Generate path for monster data

        return LoadMonsterByPath(monsterFilePath);
    }

    public static MonsterData LoadMonsterByPath(string path)
    {
        MonsterData monster;
        if (File.Exists(path)) // Check file path
        {
            string monsterStr = File.ReadAllText(path);
            monster = JsonUtility.FromJson<MonsterData>(monsterStr);
            string spritePath = "Sprites/Monsters/" + monster.Name;
            monster.Sprite = Resources.Load<Sprite>(spritePath);
        }
        else
        {
            monster = new MonsterData();
            Debug.Log("FILE NOT FOUND");
        }

        return monster;
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
            try
            {
                // Read the plain text content from the file
                string jsonText = File.ReadAllText(filePath);

                // Deserialize the text into a single ItemData object
                MonsterData data = LoadMonsterByPath(filePath);

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
