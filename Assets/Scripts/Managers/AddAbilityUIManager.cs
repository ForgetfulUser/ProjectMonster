using TMPro;
using UnityEngine;

public class AddAbilityUIManager : MonoBehaviour
{
    [Header("Texts")]
    public TMP_Text Name_TXT;
    public TMP_Text RarityType_TXT;
    public TMP_Text MonsterType_TXT;
    public TMP_Text ElementType_TXT;
    public TMP_Text Damage_TXT;
    // List Of Buffs

    [Header("Game Objects")]
    //public GameObject TargetSelfCheckMark_GO;
    public GameObject SelectBuffButton_GO;
    public GameObject DeselectBuffButton_GO;

    public void DisplayAbility(AbilityData abilityData)
    {
        if (abilityData != null)
        {
            Name_TXT.text = abilityData.Name;
            RarityType_TXT.text = abilityData.MonsterRarity.ToString();
            MonsterType_TXT.text = abilityData.MonsterType.ToString();
            ElementType_TXT.text = abilityData.Element.ToString();
            if(abilityData.Damage > 0)
            {
                Damage_TXT.color = Color.green;
                Damage_TXT.text = "Healing: ";
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

            bool isAbilityAdded = AddAbilityManager.AddAbilityInstance.IsAbilityAdded(abilityData);
            if(SelectBuffButton_GO)
                SelectBuffButton_GO.SetActive(!isAbilityAdded);
            if (DeselectBuffButton_GO)
                DeselectBuffButton_GO.SetActive(isAbilityAdded);
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
        }
    }
}
