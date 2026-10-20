using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    public SearchParameter SearchParameter;
    public List<MonsterData> MonsterDatas = new List<MonsterData>();
    public List<MonsterGiver> MonsterGivers = new List<MonsterGiver>();
    public void LoadArea()
    {
        MonsterDatas = GameManager.Instance.GetMonsterList(SearchParameter);

        foreach(MonsterGiver giver in MonsterGivers)
        {
            giver.LoadGiver(this);
        }
    }
}
