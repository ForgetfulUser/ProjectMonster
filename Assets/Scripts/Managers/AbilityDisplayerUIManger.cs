using System.Collections.Generic;
using TMPro;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplayerUIManger : MonoBehaviour
{
    [Header("Ability References")]
    public Transform AbilityContent_TRSFM;
    public AbilityHolder AbilityHolder_PRFB;
    public List<AbilityHolder> AbilityHolders = new List<AbilityHolder>();
    [Header("Selected Ability Texts")]
    public TMP_Text Name_TXT;
    public TMP_Text Description_TXT;
    public TMP_Text RarityType_TXT;
    public TMP_Text MonsterType_TXT;
    public TMP_Text ElementType_TXT;
    public TMP_Text Damage_TXT;

    [Header("Buff References")]
    public BuffHolder BuffHolder_PRFB;
    public Transform attachedBuffsContent_TRSFM;
    public List<BuffHolder> BuffHolders;
    public SelectedAbilityBuffManager SelectedAbilityBuffManager;

    public void LoadDisplayer(List<AbilityData> abilityDatas)
    {
        foreach(AbilityHolder holder in AbilityHolders)
        {
            Destroy(holder.gameObject);
        }

        AbilityHolders.Clear();

        foreach(AbilityData abilityData in abilityDatas)
        {
            AbilityHolder abilityHolder = Instantiate(AbilityHolder_PRFB, AbilityContent_TRSFM);
            abilityHolder.InitiateHolder(abilityData, AbilityHolder.HolderType.AbilityDisplayerPanel);
            AbilityHolders.Add(abilityHolder);
        }

        UpdateUI(null); 
    }

    public void UpdateUI(AbilityData abilityData)
    {
        if(abilityData == null)
        {
            Name_TXT.text = "Ability Name";
            Damage_TXT.text = "Damage/Healing: XX";
            Description_TXT.text = "Description";
            RarityType_TXT.text = "Rarity";
            MonsterType_TXT.text = "Monster Type";
            ElementType_TXT.text = "Element";
            return; 
        }

        Name_TXT.text = abilityData.Name;
        string damageText = "Healing/Damage: ";
        if (abilityData.Damage > 0)
        {
            Damage_TXT.color = Color.green;
            damageText = "Healing: ";
        }
        else if (abilityData.Damage < 0)
        {
            Damage_TXT.color = Color.red;
            damageText = "Damage: ";
        }
        else
        {
            Damage_TXT.color = Color.black;
        }
        damageText += Mathf.Abs(abilityData.Damage);
        Damage_TXT.text = damageText;
        Description_TXT.text = abilityData.Description;
        RarityType_TXT.text = abilityData.MonsterRarity.ToString();
        MonsterType_TXT.text = abilityData.MonsterType.ToString();
        ElementType_TXT.text = abilityData.Element.ToString();

        foreach(BuffHolder holder in BuffHolders)
        {
            Destroy(holder.gameObject);
        }
        BuffHolders.Clear();

        foreach(BuffData buff in abilityData.Buffs)
        {
            BuffHolder buffHolder = Instantiate(BuffHolder_PRFB, attachedBuffsContent_TRSFM);
            buffHolder.InitiateHolder(buff, BuffHolder.HolderType.AbilityDisplayerPanel);
            BuffHolders.Add(buffHolder);
        }
    }
}
