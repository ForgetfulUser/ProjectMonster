using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class MonsterTamer : MonoBehaviour
{
    public List<MonsterData> Monsters = new List<MonsterData>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(Application.dataPath);
        MonsterLoader.LoadMonsterByName("Arcanine");
        //MonsterLoader.Instance.TempSave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
