using System.Collections.Generic;
using UnityEngine;

public class AbilityMakerManager : MonoBehaviour
{
    public static AbilityMakerManager Instance;
    //public AbilityDisplayerManager AbilityfDisplayerManager;
    public GameObject MakerPanel;
    public GameObject AddBuffPanel_GO;
    public AbilityMakerUIManager AbilityMakerUIManager;
    public AddBuffManager AddBuffManager;
    public AbilityData CreatedAbility;
    public string OldName;
    public const int BASE_STATS = 5;
    public BuffData SelectedBuff;

    private void Awake()
    {
        Instance = this;
        CreatedAbility = new AbilityData();
    }

    public void UpdateBuffs(List<BuffData> buffs) 
    {
        foreach (BuffData buff in buffs)
        {
            Debug.Log(buff.Name);
        }
        CreatedAbility.Buffs = buffs;
        AbilityMakerUIManager.DisplayBuffs();
    }

    public void DisplayAddBuffs()
    {

        List<BuffData> buffs = BuffLoader.LoadAllBuffDatas(BuffLoader.BuffDataPath);
        AddBuffManager.DisplayBuffs(buffs);
        //AbilityMakerUIManager.DisplayBuffs(selfTargetBuffs);
    }

    public void SelectSelfTargetBuff(BuffData buffData)
    {
        SelectedBuff = buffData;
    }

    public void SelectNonSelfTargetBuff(BuffData buffData)
    {
        SelectedBuff = buffData;
    }
}
