using System.Collections.Generic;
using UnityEngine;

public class Rift : MonoBehaviour
{
    public SearchParameter SearchParameter;

    private GameArea GameArea;

    public List<MonsterData> MonsterDatas = new List<MonsterData>();

    public void LoadRift(GameArea gameArea)
    {
        GameArea = gameArea;
        MonsterDatas = SearchFilterSystem.FilterMonsterDatas(GameArea.MonsterDatas, SearchParameter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MonsterTamer>())
        {
            // Load Fight Scene
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
