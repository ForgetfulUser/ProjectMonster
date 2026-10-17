using System.Collections.Generic;
using UnityEngine;

public class MonsterGiver : MonoBehaviour
{
    public SearchParameter SearchParameter;
    
    private GameArea GameArea;

    public List<MonsterData> MonsterData = new List<MonsterData>();

    public void LoadGiver()
    {
        GameArea = GetComponentInParent<GameArea>();
        //MonsterData = GameArea.mons
    }
}
