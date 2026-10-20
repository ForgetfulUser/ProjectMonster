using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    public enum HolderType
    {
        AbilityDisplayerPanel,
        MonsterMakerPanel,
        AddAbilityPanel
    }

    public AbilityData Ability;
    public TMP_Text Text;
    public HolderType holderType;
    public GameObject Check_GO;

    public void InitiateHolder(AbilityData ability, HolderType holderType)
    {
        Ability = ability;
        Text.text = Ability.Name;
        this.holderType = holderType;

        switch (holderType)
        {
            case HolderType.AbilityDisplayerPanel:
                GetComponent<Button>().onClick.AddListener(SelectAbilityDisplayerPanelAbility);
                break;
            case HolderType.MonsterMakerPanel:
                GetComponent<Button>().onClick.AddListener(SelectMonsterMakerPanelAbility);
                break;
            case HolderType.AddAbilityPanel:
                GetComponent<Button>().onClick.AddListener(SelectAddAbilityPanelAbility);
                break;
        }
    }

    public void SelectAbilityDisplayerPanelAbility()
    {
        AbilityDisplayerManager.Instance.SelectAbility(Ability);
    }

    public void SelectMonsterMakerPanelAbility()
    {
        //MonsterMakerManager.Instance.SelectAbility(Ability);
    }

    public void SelectAddAbilityPanelAbility()
    {
        AddAbilityManager.Instance.DisplayAbility(Ability);
    }
}
