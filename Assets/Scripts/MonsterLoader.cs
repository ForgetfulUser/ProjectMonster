using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class MonsterLoader : MonoBehaviour
{

    public Sprite Sprite;
    public string TName = "He";
    [TextArea]
    public string Description;
    public Vector2 Health;
    public static MonsterLoader Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void TempSave()
    {
        Monster monster = new Monster
        {
            Sprite = Sprite,
            Name = TName,
            Description = Description,
            Health = Health,
        };

        string json = JsonUtility.ToJson(monster);
        File.WriteAllText(Application.dataPath + "/Monster Files/Monster.txt", json);
    }



    public void LoadData()
    {
        string fileString = Application.dataPath + "Data/data.jsn";
        if (File.Exists(fileString))
        {
            string str = File.ReadAllText(fileString);
        }
    }

    public static void LoadMonster(string name)
    {
        string monsterFilePath = Application.dataPath + "/Monster Files/" + name + ".txt";
        Debug.Log("PATH: " + monsterFilePath);
        if (File.Exists(monsterFilePath))
        {
            string monsterStr = File.ReadAllText(monsterFilePath);
            Monster monster = JsonUtility.FromJson<Monster>(monsterStr);

            Debug.Log(monster.Name);
        }
        else
        {
            Debug.Log("FILE NOT FOUND");
        }
    }
}
