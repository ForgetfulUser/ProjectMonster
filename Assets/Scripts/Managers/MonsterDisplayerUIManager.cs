using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterDisplayerUIManager : MonoBehaviour
{
    public static MonsterDisplayerUIManager Instance;
    [Header("Monster Maker Specific Variables")]
    public MonsterMakerManager MonsterMakerManager;
    public AddAbilityManager ViewAbilityManager;
    public GameObject DisplayPanel;

    [Header("Monster Giver Specific Variables")]
    public GameObject DisplayCanvas_GO;
    private MonsterGiver monsterGiver;
    public GameObject SelectButton_GO;
    public GameObject UnselectButton_GO;
    public GameObject CloseButton_GO;
    public GameObject CompleteButton_GO;

    [Header("Monster Holder Variables")]
    public MonsterHolder MonsterHolder_PRFB;
    public MonsterHolder.HolderType HolderType;
    public List<MonsterHolder> Holders;
    public Transform Content;

    [Header("Selected Monster Stuff")]
    public MonsterHolder SelectedHolder;
    public MonsterData SelectedMonster;
    public Image Sprite_IMG;
    public TMP_Text Name_TXT;
    public TMP_Text Rarity_TXT;
    public TMP_Text Type1_TXT;
    public TMP_Text Type2_TXT;
    public TMP_Text Element1_TXT;
    public TMP_Text Element2_TXT;
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

    public void StartDisplayer(List<MonsterData> monsters, MonsterGiver _monsterGiver)
    {
        monsterGiver = _monsterGiver;
        StartDisplayer(monsters);
    }

    public void StartDisplayer(List<MonsterData> monsters)
    {
        if (monsterGiver == null)
            DisplayPanel.SetActive(true);

        foreach (MonsterHolder holder in Holders)
        {
            Destroy(holder.gameObject);
        }
        Holders.Clear();
        foreach (MonsterData monster in monsters)
        {
            MonsterHolder holder = Instantiate(MonsterHolder_PRFB, Content);
            holder.InitiateHolder(monster, HolderType);
            Holders.Add(holder);
        }

        SelectMonster(MonsterHolder_PRFB);
    }

    public void SelectMonster(MonsterHolder monsterHolder)
    {
        Button button = GetComponent<Button>();
        
        SelectedHolder = monsterHolder;
        SelectedMonster = SelectedHolder.Monster;

        Sprite_IMG.sprite = SelectedMonster.Sprite;

        Name_TXT.text = SelectedMonster.Name;
        Rarity_TXT.text = SelectedMonster.MonsterRarity.ToString();
        Type1_TXT.text = SelectedMonster.MonsterType1.ToString();
        Type2_TXT.text = SelectedMonster.MonsterType2 != MonsterType.None ? SelectedMonster.MonsterType2.ToString() : "";
        if (Type2_TXT.text == "") Type2_TXT.gameObject.SetActive(false); else Type2_TXT.gameObject.SetActive(true);
        Element1_TXT.text = SelectedMonster.Element1.ToString();
        Element2_TXT.text = SelectedMonster.Element2 != ElementType.None ? SelectedMonster.Element2.ToString() : "";
        if (Element2_TXT.text == "") Element2_TXT.gameObject.SetActive(false); else Element2_TXT.gameObject.SetActive(true);
        Description_TXT.text = SelectedMonster.Description;
        Health_TXT.text = "Max Health: " + SelectedMonster.Health.y;
        Speed_TXT.text = "Speed: " + SelectedMonster.Speed;
        PhysicalAttack_TXT.text = "Physical Attack: " + SelectedMonster.PhysicalAttack;
        PhysicalDefense_TXT.text = "Physical Defense: " + SelectedMonster.PhysicalDefense;
        MagicalAttack_TXT.text = "Magical Attack: " + SelectedMonster.MagicalAttack;
        MagicalDefense_TXT.text = "Magical Defense: " + SelectedMonster.MagicalDefense;

        if(SelectedHolder.MonHolderType == MonsterHolder.HolderType.MonsterGiver)
        {
            SelectButton_GO.SetActive(SelectedHolder.Check_GO.activeSelf == false);
            UnselectButton_GO.SetActive(SelectedHolder.Check_GO.activeSelf == true);
        }
    }

    public void EditMonster()
    {
        MonsterMakerManager.EditMonster(SelectedMonster);
        // MonsterLoader.DeleteMonster(SelectedMonster.Name);
        BackToMakeMonters();
    }

    public void ChooseSelectedMonster()
    {
        if (monsterGiver.SelectMonster(SelectedMonster))
        {
            SelectedHolder.Check_GO.SetActive(true);
            CloseButton_GO.SetActive(false);
            CompleteButton_GO.SetActive(true);
            SelectButton_GO.SetActive(false);
            UnselectButton_GO.SetActive(true);
        }
    }

    public void UnchooseSelectedMonster()
    {
        monsterGiver.RemoveMonster(SelectedMonster);
        SelectedHolder.Check_GO.SetActive(false);
        SelectButton_GO.SetActive(true);
        UnselectButton_GO.SetActive(false);
        if (monsterGiver.SelectedMonsters.Count == 0)
        {
            CloseButton_GO.SetActive(true);
            CompleteButton_GO.SetActive(false);
        }
    }

    public void OpenAddAbilitiesPanel()
    {
        ViewAbilityManager.DisplayAbilities(SelectedMonster.Abilities);
    }

    public void BackToMakeMonters()
    {
        DisplayPanel.SetActive(false);
        MonsterMakerManager.MakerPanel.SetActive(true);
    }

    public void Complete()
    {
        monsterGiver.Complete();
        CloseCanvas();
    }

    public void CloseCanvas()
    {
        Destroy(DisplayCanvas_GO);
        GameManager.Instance.PlayerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
