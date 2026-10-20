using TMPro;
using UnityEngine;

public class AddAbilityUIManager : MonoBehaviour
{
    [Header("Texts")]
    public TMP_Text Name_TXT;
    public TMP_Text RarityType_TXT;
    public TMP_Text MonsterType_TXT;
    public TMP_Text ElementType_TXT;
    // List Of Buffs

    [Header("Game Objects")]
    //public GameObject TargetSelfCheckMark_GO;
    public GameObject SelectBuffButton_GO;
    public GameObject DeselectBuffButton_GO;

    public void DisplayAbility(AbilityData abilityData)
    {
        if (abilityData != null)
        {
            /*
            string statTypeText = "Stat Type Not Found";
            switch (abilityData.AffectingStat)
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

            Name_TXT.text = abilityData.Name;
            StatType_TXT.text = statTypeText + ": " + abilityData.AffectingStatAmount;
            if (statTypeText == "None") StatType_TXT.text = "None";
            Condition_TXT.text = abilityData.Condition.ToString();
            if (abilityData.Condition == ConditionType.MAX_CONDITION_TYPE) Condition_TXT.text = "None";
            TurnsAmount_TXT.text = "Turns Amount: " + abilityData.MaxTurns;

            TargetSelfCheckMark_GO.SetActive(abilityData.DoesTargetSelf);
            */
            bool isAbilityAdded = AddAbilityManager.Instance.IsAbilityAdded(abilityData);
            SelectBuffButton_GO.SetActive(!isAbilityAdded);
            DeselectBuffButton_GO.SetActive(isAbilityAdded);
        }
        else
        {
            Name_TXT.text = "Select A Buff";

            RarityType_TXT.text = "Monster Rarity";
            MonsterType_TXT.text = "Monster Type";
            ElementType_TXT.text = "Element Type";

            //TargetSelfCheckMark_GO.SetActive(false);

            SelectBuffButton_GO.SetActive(false);
            DeselectBuffButton_GO.SetActive(false);
        }
    }
}
