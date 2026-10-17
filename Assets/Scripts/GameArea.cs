using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    public SearchParameter SearchParameter;
    public List<MonsterData> MonsterDatas = new List<MonsterData>();

    public void LoadArea()
    {
        MonsterDatas = GameManager.Instance.GetMonsterList(SearchParameter);
    }
}
