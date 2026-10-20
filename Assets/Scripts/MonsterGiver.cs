using System.Collections.Generic;
using UnityEngine;

public class MonsterGiver : MonoBehaviour, IInteractable
{
    public GameObject InteractTip_GO;
    public GameObject MonsterGiverCanvas_PRFB;
    public SearchParameter SearchParameter;
    public int MaxSelectableMonsters;
    public bool MonstersWereSelected;
    
    private GameArea GameArea;

    public List<MonsterData> MonsterDatas = new List<MonsterData>();
    public List<MonsterData> SelectedMonsters = new List<MonsterData>();

    public void LoadGiver(GameArea gameArea)
    {
        GameArea = gameArea;
        MonsterDatas = SearchFilterSystem.FilterMonsterDatas(GameArea.MonsterDatas, SearchParameter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInteract>())
        {
            other.GetComponent<PlayerInteract>().Interactable = this;
            InteractTip_GO.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInteract>())
        {
            other.GetComponent<PlayerInteract>().Interactable = null;
            InteractTip_GO.SetActive(false);
        }
    }

    public bool SelectMonster(MonsterData monster)
    {
        bool didSelect = false;
        if(SelectedMonsters.Count < MaxSelectableMonsters)
        {
            SelectedMonsters.Add(monster);
            didSelect = true;
        }
        return didSelect;
    }

    public void RemoveMonster(MonsterData monster)
    {
        foreach(MonsterData monsterData in SelectedMonsters)
        {
            if(monsterData.Name == monster.Name)
            {
                SelectedMonsters.Remove(monsterData);
                break;
            }
        }
    }

    public void Complete()
    {
        foreach (MonsterData monster in SelectedMonsters)
        {
            GameManager.Instance.PlayerTamer.ReceiveMonster(monster);
        }
        MonstersWereSelected = true;
    }

    public void Interact()
    {
        if (MonstersWereSelected) return;
        GameObject canvas = Instantiate(MonsterGiverCanvas_PRFB);
        canvas.GetComponentInChildren<MonsterDisplayerUIManager>().StartDisplayer(MonsterDatas, this);
    }
}
