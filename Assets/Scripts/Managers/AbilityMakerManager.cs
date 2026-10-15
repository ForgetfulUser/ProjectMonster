using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AbilityMakerManager : MonoBehaviour
{
    public static AbilityMakerManager Instance;
    //public AbilityDisplayerManager AbilityfDisplayerManager;
    public GameObject MakerPanel;
    public GameObject DisplayerPanel;
    public GameObject AddBuffPanel_GO;
    public AbilityMakerUIManager AbilityMakerUIManager;
    public SelectedAbilityBuffManager SelectedAbilityBuffManager;
    public AddBuffManager AddBuffManager;
    public AbilityDisplayerManager AbilityDisplayerManager;
    public AbilityData CreatedAbility;
    public string OldName;
    public const int BASE_STATS = 5;

    private void Awake()
    {
        Instance = this;
        CreatedAbility = new AbilityData();
    }

    public void EditAbility(AbilityData ability)
    {
        CreatedAbility = ability;
        OldName = ability.Name;
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void DisplayAbilities()
    {
        MakerPanel.SetActive(false);
        DisplayerPanel.SetActive(true);
        AbilityDisplayerManager.LoadAbilityDisplayer();
    }

    public void ChangeAbilityName(string name)
    {
        CreatedAbility.Name = name;
    }

    public void ChangeAbilityDescription(string description)
    {
        CreatedAbility.Description = description;
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void ChangeAbilityDamage(Single damage)
    {
        CreatedAbility.Damage = (int)damage;
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void ChangeDoesTargetSelf(bool doesTargetSelf)
    {
        CreatedAbility.DoesTargetSelf = doesTargetSelf;
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void ChangeAbilityRartiy(int monsterRarity)
    {
        CreatedAbility.MonsterRarity = (RarityType)monsterRarity;
        
        // Adjust Damage/Healing Min and Max values
        int damageMinMax = 0;
        switch((RarityType)monsterRarity)
        {
            case RarityType.None:
                damageMinMax = 3;
                break;
            case RarityType.Common:
                damageMinMax = 5;
                break;
            case RarityType.Uncommon:
                damageMinMax = 12;
                break;
            case RarityType.Rare:
                damageMinMax = 15;
                break;
            case RarityType.Epic:
                damageMinMax = 18;
                break;
            case RarityType.Legendary:
                damageMinMax = 21;
                break;
            case RarityType.Mythic:
                damageMinMax = 25;
                break;
            case RarityType.Ancient:
                damageMinMax = 30;
                break;
        }
        AbilityMakerUIManager.AdjustDamageMinMax(-damageMinMax, damageMinMax);
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void ChangeMonsterType(int monsterType)
    {
        CreatedAbility.MonsterType = (MonsterType)monsterType;
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void ChangeElementType(int elementType)
    {
        CreatedAbility.Element = (ElementType)elementType;
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void ChangeBuffs(List<BuffData> buffs) 
    {
        CreatedAbility.Buffs = buffs;
        AbilityMakerUIManager.DisplayBuffs();
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void ChangeDescription(string description)
    {
        CreatedAbility.Description = description;
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void DisplayAddBuffs()
    {
        List<BuffData> buffs = BuffLoader.LoadAllBuffDatas(BuffLoader.BuffDataPath);
        AddBuffManager.DisplayBuffs(buffs);
        AbilityMakerUIManager.UpdateMakerUI();
    }

    public void SelectBuff(BuffData buffData)
    {
        SelectedAbilityBuffManager.SelectBuff(buffData);
    }

    public void SaveAbility()
    {
        if (CreatedAbility.Name == "Ability")
        {
            Debug.Log("Rename Ability");
            return;
        }
        else if (OldName != "")
        {
            AbilityLoader.DeleteAbility(OldName);
        }
        OldName = "";

        AbilityLoader.SaveAbility(CreatedAbility);
        SceneManager.LoadScene("Monster Maker Scene");
    }
}
