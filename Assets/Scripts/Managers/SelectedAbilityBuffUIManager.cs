using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SelectedAbilityBuffUIManager : MonoBehaviour
{
    public TMP_Text Name_TXT;
    public TMP_Text AffectingStat_TXT;
    public TMP_Text Condition_TXT;
    public GameObject DoesTargetSelf_GO;
    public TMP_Text TurnAmount_TXT;

    public void UpdateSelectedBuff(BuffData buff)
    {
        if (buff == null)
        {
            Name_TXT.text = "Buff Name";
            AffectingStat_TXT.text = "Affecting Stat: +/-XX";
            Condition_TXT.text = "Condition";
            DoesTargetSelf_GO.SetActive(true);
            TurnAmount_TXT.text = "Turns Amount: XX";
            return;
        }
        Name_TXT.text = buff.Name;

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
