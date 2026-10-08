using System.Collections.Generic;
using UnityEngine;

public class AbilityMakerManager : MonoBehaviour
{
    public static AbilityMakerManager Instance;
    //public AbilityDisplayerManager AbilityfDisplayerManager;
    public GameObject MakerPanel;
    //public BuffDisplayerUIManager BuffDisplayerUIManager;
    public AbilityMakerUIManager AbilityMakerUIManager;
    public AbilityData CreatedAbility;
    public string OldName;
    public const int BASE_STATS = 5;
    public BuffData SelectedBuff;

    private void Awake()
    {
        Instance = this;
        CreatedAbility = new AbilityData();
    }

    private void Start()
    {
        LoadBuffs();
    }

    public void LoadBuffs()
    {
        List<BuffData> selfTargetBuffs = BuffLoader.LoadAllSelfBuffDatas(BuffLoader.BuffDataPath);
        List<BuffData> nonSelfTargetBuffs = BuffLoader.LoadAllNonSelfBuffDatas(BuffLoader.BuffDataPath);

        AbilityMakerUIManager.DisplayBuffs(selfTargetBuffs, nonSelfTargetBuffs);
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
