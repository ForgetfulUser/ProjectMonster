using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class MonsterTamer : MonoBehaviour
{
    public List<MonsterData> Monsters = new List<MonsterData>();
    
    public void ReceiveMonster(MonsterData monster)
    {
        if (Monsters.Count + 1 <= 6)
        {
            Monsters.Add(monster);
        }
    }
}
