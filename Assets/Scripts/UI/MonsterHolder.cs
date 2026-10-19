using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterHolder : MonoBehaviour
{
    public enum HolderType
    {
        MonsterMaker,
        MonsterGiver
    }

    MonsterDisplayerUIManager MonsterDisplayerUIManager;
    public MonsterData Monster;
    public TMP_Text Text;
    public GameObject Check_GO;
    [HideInInspector] public HolderType MonHolderType;
    public void InitiateHolder(MonsterData monster, HolderType holderType)
    {
        Monster = monster;
        Text.text = Monster.Name;
        MonHolderType = holderType;

        switch (MonHolderType)
        {
            case HolderType.MonsterMaker:
                GetComponent<Button>().onClick.AddListener(SelectMonsterMakerHolder); 
                break;
            case HolderType.MonsterGiver:
                GetComponent<Button>().onClick.AddListener(SelectMonsterGiverHolder); 
                break;
        }
    }

    public void SelectMonsterMakerHolder()
    {
        MonsterDisplayerUIManager.Instance.SelectMonster(this);
    }

    public void SelectMonsterGiverHolder()
    {
        MonsterDisplayerUIManager.Instance.SelectMonster(this);
    }
}
