using System.Collections.Generic;
using UnityEngine;

public class AbilityDisplayerManager : MonoBehaviour
{
    public static AbilityDisplayerManager Instance;
    public AbilityDisplayerUIManger AbilityDisplayerUIManger;
    public SelectedAbilityBuffManager SelectedAbilityBuffManager;
    public GameObject MakerPanel_GO;
    public GameObject DisplayerPanel_GO;
    public AbilityData SelectedAbility;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadAbilityDisplayer()
    {
        List<AbilityData> abilityDatas = AbilityLoader.LoadAllAbilityDatas();
        AbilityDisplayerUIManger.LoadDisplayer(abilityDatas);
        SelectedAbilityBuffManager.SelectBuff(null);
    }

    public void SelectAbility(AbilityData abilityData)
    {
        SelectedAbility = abilityData;

        AbilityDisplayerUIManger.UpdateUI(SelectedAbility);
    }

    public void SelectBuff(BuffData buff)
    {
        SelectedAbilityBuffManager.SelectBuff(buff);
    }

    public void EditAbility()
    {
        AbilityMakerManager.Instance.EditAbility(SelectedAbility);
        BackToAbilityMaker();
    }

    public void BackToAbilityMaker()
    {
        MakerPanel_GO.SetActive(true);
        DisplayerPanel_GO.SetActive(false);
    }
}
