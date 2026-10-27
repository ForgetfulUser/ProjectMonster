using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddAbilityUIManager : MonoBehaviour
{
    public bool IsAddAbility = true;

    [Header("Texts")]
    public TMP_Text Name_TXT;
    public TMP_Text RarityType_TXT;
    public TMP_Text MonsterType_TXT;
    public TMP_Text ElementType_TXT;
    public TMP_Text Damage_TXT;
    public TMP_Text Description_TXT;
    // List Of Buffs

    [Header("Game Objects")]
    //public GameObject TargetSelfCheckMark_GO;
    public GameObject SelectBuffButton_GO;
    public GameObject DeselectBuffButton_GO;

    [Header("Buff References")]
    public BuffHolder BuffHolder_PRFB;
    public Transform BuffContent_TRSFM;
    public List<BuffHolder> BuffHolders;
    public TMP_Text BuffName_TXT;
    public TMP_Text AffectingStat_TXT;
    public TMP_Text Condition_TXT;
    public GameObject DoesTargetSelf_GO;
    public TMP_Text TurnAmount_TXT;

    public void DisplayAbility(AbilityData abilityData)
    {
        foreach (BuffHolder holder in BuffHolders)
        {
            Destroy(holder.gameObject);
        }
        BuffHolders.Clear();

        DisplayBuff(null);

        if (abilityData != null)
        {
            Name_TXT.text = abilityData.Name;
            RarityType_TXT.text = abilityData.MonsterRarity.ToString();
            MonsterType_TXT.text = abilityData.MonsterType.ToString();
            ElementType_TXT.text = abilityData.Element.ToString();
            if(abilityData.Damage > 0)
            {
                Damage_TXT.color = Color.green;
                Damage_TXT.text = "Healing: +";
            }
            else if(abilityData.Damage < 0)
            {
                Damage_TXT.color = Color.red;
                Damage_TXT.text = "Damage: ";
            }
            else 
            {
                Damage_TXT.text = "Damage/Healing: ";
                Damage_TXT.color = Color.black;
            }
            Damage_TXT.text += abilityData.Damage.ToString();

            foreach(BuffData buff in abilityData.Buffs)
            {
                BuffHolder holder = Instantiate(BuffHolder_PRFB, BuffContent_TRSFM);
                BuffHolder.HolderType holderType = IsAddAbility ? BuffHolder.HolderType.AddAbilityPanel : BuffHolder.HolderType.ViewAbilityPanel;
                holder.InitiateHolder(buff, holderType);
                BuffHolders.Add(holder);
            }

            bool isAbilityAdded = AddAbilityManager.AddAbilityInstance.IsAbilityAdded(abilityData);
            if(SelectBuffButton_GO)
                SelectBuffButton_GO.SetActive(!isAbilityAdded);
            if (DeselectBuffButton_GO)
                DeselectBuffButton_GO.SetActive(isAbilityAdded);
            Debug.Log(abilityData.Description);
            Description_TXT.text = abilityData.Description;
        }
        else
        {
            Name_TXT.text = "Select An Ability";

            RarityType_TXT.text = "Monster Rarity";
            MonsterType_TXT.text = "Monster Type";
            ElementType_TXT.text = "Element Type";
            Damage_TXT.text = "Damage/Healing: XXX";
            Damage_TXT.color = Color.black;

            //TargetSelfCheckMark_GO.SetActive(false);

            if (SelectBuffButton_GO)
                SelectBuffButton_GO.SetActive(false);
            if (DeselectBuffButton_GO)
                DeselectBuffButton_GO.SetActive(false);
            
            Description_TXT.text = "Ability Description";
        }

    }

    public void DisplayBuff(BuffData buff)
    {
        if (buff == null)
        {
            BuffName_TXT.text = "Buff Name";
            AffectingStat_TXT.text = "Affecting Stat: +/-XX";
            Condition_TXT.text = "Condition";
            DoesTargetSelf_GO.SetActive(true);
            TurnAmount_TXT.text = "Turns Amount: XX";
            return;
        }
        BuffName_TXT.text = buff.Name;

        string affectStatText = "";
        switch (buff.AffectingStat)
        {
            case StatType.MagicalDefense:
                affectStatText = "Magical Defense";
                break;
            case StatType.MagicalAttack:
                affectStatText = "Magical Attack";
                break;
            case StatType.PhysicalAttack:
                affectStatText = "Physical Attack";
                break;
            case StatType.PhysicalDefense:
                affectStatText = "Physical Defense";
                break;
            case StatType.Health:
                affectStatText = "Health";
                break;
            case StatType.Speed:
                affectStatText = "Speed";
                break;
        }
        affectStatText += ": " + buff.AffectingStatAmount;
        if (buff.AffectingStat == StatType.MAX_STAT_TYPE) affectStatText = "None";
        AffectingStat_TXT.text = affectStatText;

        Condition_TXT.text = buff.Condition != ConditionType.MAX_CONDITION_TYPE ? buff.Condition.ToString() : "None";
        DoesTargetSelf_GO.SetActive(buff.DoesTargetSelf);
        TurnAmount_TXT.text = "Turns Amount: " + buff.MaxTurns;
    }
}
