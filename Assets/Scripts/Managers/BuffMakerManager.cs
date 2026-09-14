using System;
using System.Collections.Generic;
using UnityEngine;

public class BuffMakerManager : MonoBehaviour
{
    public GameObject MakerPanel;
    //public BuffDisplayerUIManager BuffDisplayerUIManager;
    public BuffMakerUIManager BuffMakerUIManager;
    public BuffData CreatedBuff;
    public int StatPoints;

    public const int BASE_STATS = 5;

    public void UpdateName(string name)
    {
        CreatedBuff.Name = name;
        BuffMakerUIManager.UpdateBuffUI();
    }

    public void UpdateTurnAmount(int turnAmount)
    {
        CreatedBuff.MaxTurns = turnAmount;
    }

    public void UpdateAffectingStat(Int32 stat)
    {
        CreatedBuff.BuffingStat = (StatType)stat;
    }

    public void UpdateAffectingStatAmount(int amount)
    {
        CreatedBuff.StatBuffAmount = amount;
    }
}
