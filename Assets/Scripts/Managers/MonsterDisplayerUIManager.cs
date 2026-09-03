using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MonsterDisplayerUIManager : MonoBehaviour
{
    public static MonsterDisplayerUIManager Instance;
    public MonsterMakerManager MonsterMakerManager;
    public GameObject DisplayPanel;
    public MonsterHolder MonsterHolder_PRFB;
    public List<MonsterHolder> Holders;
    public Transform Content;

    public MonsterData SelectedMonster;
    [Header("Selected Monster Stuff")]
    public Image Sprite_IMG;
    public TMP_Text Name_TXT;
    public TMP_Text Description_TXT;
    public TMP_Text Health_TXT;
    public TMP_Text Speed_TXT;
    public TMP_Text PhysicalAttack_TXT;
    public TMP_Text PhysicalDefense_TXT;
    public TMP_Text MagicalAttack_TXT;
    public TMP_Text MagicalDefense_TXT;

    private void Awake()
    {
        Instance = this;
    }

    public void StartDisplayer(List<MonsterData> monsters)
    {
        DisplayPanel.SetActive(true);
        foreach(MonsterHolder holder in Holders)
        {
            Destroy(holder.gameObject);
        }
        Holders.Clear();
        foreach (MonsterData monster in monsters) 
        {
            MonsterHolder holder = Instantiate(MonsterHolder_PRFB, Content);
            holder.InitiateHolder(monster);
            Holders.Add(holder);
        }

        SelectMonster(new MonsterData());
    }

    public void SelectMonster(MonsterData monster)
    {
        Name_TXT.text = monster.Name;
        Description_TXT.text = monster.Description;
        Health_TXT.text = "Max Health: " + monster.Health.y;
        Speed_TXT.text = "Speed: " + monster.Speed;
        PhysicalAttack_TXT.text = "Phys. Attack: " + monster.PhysicalAttack;
        PhysicalDefense_TXT.text = "Phys. Defense: " + monster.PhysicalDefense;
        MagicalAttack_TXT.text = "Mag. Attack: " + monster.MagicalAttack;
        MagicalDefense_TXT.text = "Mag. Defense: " + monster.MagicalDefense;

        Debug.Log(monster.Sprite);

        if(monster.Sprite != null)
        {
            Sprite_IMG.gameObject.SetActive(true);
            Sprite_IMG.sprite = monster.Sprite;
        }
        else
        {
            Sprite_IMG.gameObject.SetActive(false);
        }
    }

    public void BackToMakeMonters()
    {
        DisplayPanel.SetActive(false);
        MonsterMakerManager.MakerPanel.SetActive(true);
    }
}
