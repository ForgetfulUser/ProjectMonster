using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuffMakerManager : MonoBehaviour
{
    public static BuffMakerManager Instance;
    public BuffDisplayerManager BuffDisplayerManager;
    public GameObject MakerPanel;
    //public BuffDisplayerUIManager BuffDisplayerUIManager;
    public BuffMakerUIManager BuffMakerUIManager;
    public BuffData CreatedBuff;
    public string OldName;
    public const int BASE_STATS = 5;

    private void Awake()
    {
        Instance = this;
        CreatedBuff = new BuffData();
    }

    public void SaveBuff()
    {

        if (CreatedBuff.Name == "Buff")
        {
            Debug.Log("Rename Buff");
            return;
        }
        else if(OldName != "")
            BuffLoader.DeleteBuff(OldName);
            BuffLoader.SaveBuff(CreatedBuff);
        SceneManager.LoadScene("Monster Maker Scene");
    }

    public void UpdateName(string name)
    {
        CreatedBuff.Name = name;
        BuffMakerUIManager.UpdateBuffUI();
    }

    public void UpdateDescription(string description)
    {
        CreatedBuff.Description = description;
        BuffMakerUIManager.UpdateBuffUI();
    }

    public void UpdateTurnAmount(Single turnAmount)
    {
        CreatedBuff.MaxTurns = (int)turnAmount;
        BuffMakerUIManager.UpdateBuffUI();
    }

    public void UpdateAffectingStat(Int32 stat)
    {
        if (stat == 0)
            stat = (int)StatType.MAX_STAT_TYPE;
        else stat--;
        CreatedBuff.AffectingStat = (StatType)stat;

        BuffMakerUIManager.UpdateBuffUI();
    }

    public void UpdateAffectingStatAmount(Single amount)
    {
        CreatedBuff.AffectingStatAmount = (int)amount;
        BuffMakerUIManager.UpdateBuffUI();
    }

    public void UpdateCondition(Int32 condition)
    {
        if (condition == 0) condition = (int)ConditionType.MAX_CONDITION_TYPE;
        else condition--;
        CreatedBuff.Condition = (ConditionType)condition;
        BuffMakerUIManager.UpdateBuffUI();
    }

    public void OpenCreatedBuffs()
    {
        MakerPanel.SetActive(false);
        BuffDisplayerManager.StartDisplayer();
    }

    public void EditBuff()
    {
        CreatedBuff = BuffDisplayerManager.Instance.SelectedBuff;
        BuffMakerUIManager.UpdateBuffUI();
        BuffDisplayerUIManager.Instance.SwapScreens();
    }
}
