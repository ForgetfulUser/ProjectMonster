using System.Collections.Generic;
using UnityEngine;

public class AddAbilityManager : MonoBehaviour
{
    public static AddAbilityManager Instance;
    public AddAbilityUIManager AddAbilityUIManager;
    public GameObject AbilitiesToAddPanel_GO;
    public Transform AbilitiesContent_TRNSFM;
    public AbilityHolder AbilityHolder_PRFB;
    public List<AbilityHolder> AbilityHolders = new List<AbilityHolder>();
    public List<string> SelectedAbilityNames = new List<string>();
    public AbilityData DisplayingAbility;

    void Awake()
    {
        Instance = this;
    }

    public void DisplayAbilities(List<AbilityData> abilities)
    {
        foreach (AbilityHolder holder in AbilityHolders)
        {
            Destroy(holder.gameObject);
        }
        AbilityHolders.Clear();

        foreach (AbilityData ability in abilities)
        {
            AbilityHolder buffHolder = Instantiate(AbilityHolder_PRFB, AbilitiesContent_TRNSFM);
            buffHolder.InitiateHolder(ability, AbilityHolder.HolderType.AddAbilityPanel);
            AbilityHolders.Add(buffHolder);
        }

        SelectedAbilityNames = MonsterMakerManager.Instance.CreatedMonster.AbilityNames;

        UpdateAbilityHolders();
        DisplayAbility(null);
        AbilitiesToAddPanel_GO.SetActive(true);
    }

    public void DisplayAbility(AbilityData ability)
    {
        DisplayingAbility = ability;
        AddAbilityUIManager.DisplayAbility(ability);
    }

    public void SelectAbility(bool isSelecting)
    {
        if (isSelecting == true)
        {
            SelectedAbilityNames.Add(DisplayingAbility.Name);
        }
        else
        {
            RemoveBuff();
        }

        UpdateAbilityHolders();

        AddAbilityUIManager.DisplayAbility(DisplayingAbility);
    }

    private void RemoveBuff()
    {
        string buffToRemove = DisplayingAbility.Name;
        foreach (string name in SelectedAbilityNames)
        {
            if (name == DisplayingAbility.Name)
            {
                buffToRemove = name;
                break;
            }
        }
        SelectedAbilityNames.Remove(buffToRemove);
    }

    public void UpdateAbilityHolders()
    {
        foreach (AbilityHolder holder in AbilityHolders)
        {
            holder.Check_GO.SetActive(IsAbilityAdded(holder.Ability));
        }
    }

    public void Complete()
    {
        MonsterMakerManager.Instance.CreatedMonster.AbilityNames = SelectedAbilityNames;
        Close();
    }

    public bool IsAbilityAdded(AbilityData ability)
    {
        bool abilityIsAdded = false;
        foreach (string abilityName in SelectedAbilityNames)
        {
            if (abilityName == ability.Name)
            {
                abilityIsAdded = true;
                break;
            }
        }
        return abilityIsAdded;
    }

    public void Close()
    {
        AbilitiesToAddPanel_GO.SetActive(false);
        DisplayAbility(null);
    }
}
