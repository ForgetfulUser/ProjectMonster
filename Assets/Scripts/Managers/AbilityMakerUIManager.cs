using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions.Must;


public class AbilityMakerUIManager : MonoBehaviour
{
    [Header("Text References")]
    public TMP_InputField Name_IF;
    public TMP_Text Damage_TXT;
    public TMP_InputField Description_IF;

    [Header("Slider")]
    public Slider Damage_SLDR;

    [Header("Dropdowns")]
    public TMP_Dropdown MonsterRarity_DRPDN;
    public TMP_Dropdown MonsterType_DRPDN;
    public TMP_Dropdown Element_DRPDN;

    [Header("Toggle")]
    public Toggle DoesTargetSelf_TGL;

    [Header("Buff References")]
    public GameObject AttachtedBuffsContent_GO;
    public BuffHolder BuffHolder_PRFB;
    public List<BuffHolder> BuffHolders = new List<BuffHolder>();

    public void UpdateMakerUI() 
    {
        AbilityData ability = AbilityMakerManager.Instance.CreatedAbility;
        Debug.Log(ability.Damage);
        Name_IF.text = ability.Name;
        string damageText = "Healing/Damage: ";
        if(ability.Damage > 0)
        {
            Damage_TXT.color = Color.green;
            damageText = "Healing: ";
        }
        else if (ability.Damage < 0)
        {
            Damage_TXT.color = Color.red;
            damageText = "Damage: ";
        }
        else
        {
            Damage_TXT.color = Color.black;
        }

        damageText += Mathf.Abs(ability.Damage);
        Damage_TXT.text = damageText;
        Damage_SLDR.value = ability.Damage;

        MonsterRarity_DRPDN.value = (int)ability.MonsterRarity;
        MonsterType_DRPDN.value = (int)ability.MonsterType;
        Element_DRPDN.value = (int)ability.Element;

        Description_IF.text = ability.Description;
        
        DoesTargetSelf_TGL.isOn = ability.DoesTargetSelf;

        DisplayBuffs();
    }

    public void AdjustDamageMinMax(int min, int max, bool changeDamage)
    {
        Damage_SLDR.minValue = min;
        Damage_SLDR.maxValue = max;
        if(changeDamage)
            AbilityMakerManager.Instance.ChangeAbilityDamage(0);
    }

    public void DisplayBuffs()
    {
        foreach(BuffHolder holder in BuffHolders)
        {
            Destroy(holder.gameObject);
        }

        BuffHolders.Clear();
        AbilityMakerManager.Instance.CreatedAbility.LoadBuffs();
        List<BuffData> buffs = AbilityMakerManager.Instance.CreatedAbility.Buffs;
        foreach(BuffData data in buffs)
        {
            BuffHolder holder = Instantiate(BuffHolder_PRFB, AttachtedBuffsContent_GO.transform);
            holder.InitiateHolder(data, BuffHolder.HolderType.AbilityMakerPanel);
            BuffHolders.Add(holder);
        }
    }
}