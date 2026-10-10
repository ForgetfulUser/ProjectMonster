
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddBuffUIManager : MonoBehaviour
{
    [Header("Texts")]
    public TMP_Text Name_TXT;
    public TMP_Text StatType_TXT;
    public TMP_Text Condition_TXT;
    public TMP_Text TurnsAmount_TXT;

    [Header("Game Objects")]
    public GameObject TargetSelfCheckMark_GO;
    public GameObject SelectBuffButton_GO;
    public GameObject DeselectBuffButton_GO;

    public void DisplayBuff(BuffData buffData)
    {
        if (buffData != null)
        {
            string statTypeText = "Stat Type Not Found";
            switch (buffData.AffectingStat)
            {
                case StatType.Health:
                    statTypeText = "Health";
                    break;
                case StatType.PhysicalDefense:
                    statTypeText = "Physical Defense";
                    break;
                case StatType.PhysicalAttack:
                    statTypeText = "Physical Attack";
                    break;
                case StatType.MagicalDefense:
                    statTypeText = "Magical Defense";
                    break;
                case StatType.MagicalAttack:
                    statTypeText = "Magical Attack";
                    break;
                case StatType.Speed:
                    statTypeText = "Speed";
                    break;
                case StatType.MAX_STAT_TYPE:
                    statTypeText = "None";
                    break;
            }

            Name_TXT.text = buffData.Name;
            StatType_TXT.text = statTypeText + ": " + buffData.AffectingStatAmount;
            if(statTypeText == "None") StatType_TXT.text = "None";
            Condition_TXT.text = buffData.Condition.ToString();
            if (buffData.Condition == ConditionType.MAX_CONDITION_TYPE) Condition_TXT.text = "None";
            TurnsAmount_TXT.text = "Turns Amount: " + buffData.MaxTurns;
            
            TargetSelfCheckMark_GO.SetActive(buffData.DoesTargetSelf);
            bool isBuffAdded = AddBuffManager.Instance.IsBuffAdded(buffData);
            SelectBuffButton_GO.SetActive(!isBuffAdded);
            DeselectBuffButton_GO.SetActive(isBuffAdded);
        }
        else
        {
            Name_TXT.text = "Select A Buff";

            StatType_TXT.text = "StatType: +/-XX";
            Condition_TXT.text = "Condition";
            TargetSelfCheckMark_GO.SetActive(false);
            TurnsAmount_TXT.text = "Turns Amount: XXX";

            SelectBuffButton_GO.SetActive(false);
            DeselectBuffButton_GO.SetActive(false);
        }
    }
}
