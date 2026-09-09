using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class MonsterMakerUIManager : MonoBehaviour
{
    public MonsterMakerManager MonsterMakerManager;
    public TMP_Text StatPoint_TXT;

    public TMP_InputField MonsterName_IF;

    [Header("Stat Texts")]
    public List<TMP_Text> StatTypes_TXTs = new List<TMP_Text>();

    [Header("Stat Sliders")]
    public List<Slider> StatTypes_SLDRs = new List<Slider>();

    private Dictionary<StatTypes, TMP_Text> m_StatTypes_TXTs = new Dictionary<StatTypes, TMP_Text>();
    private Dictionary<StatTypes, Slider> m_StatTypes_SLDRs = new Dictionary<StatTypes, Slider>();

    [Header("Dropdowns")]
    public TMP_Dropdown MonsterRariry_DRPDN;
    public TMP_Dropdown MonsterClass_DRPDN;


    public List<string> stat_STRs = new List<string>();
    private Dictionary<StatTypes, string> m_stat_STRs = new Dictionary<StatTypes, string>();

    private void Start()
    {
        for(int i = 0; i< (int)StatTypes.MAX_STAT_TYPE; i++)
        {
            m_StatTypes_TXTs.Add((StatTypes)i, StatTypes_TXTs[i]);
        }
        for(int i = 0; i< (int)StatTypes.MAX_STAT_TYPE; i++)
        {
            m_StatTypes_SLDRs.Add((StatTypes)i, StatTypes_SLDRs[i]);
        }
        for(int i = 0; i< (int)StatTypes.MAX_STAT_TYPE; i++)
        {
            m_stat_STRs.Add((StatTypes)i, stat_STRs[i]);
        }

        SetBaseStats();
    }

    public void SetBaseStats()
    {
        for(int i = 0; i < (int)StatTypes.MAX_STAT_TYPE; i++)
        {
            if (i == 0)
            {
                m_StatTypes_TXTs[(StatTypes)i].text = m_stat_STRs[(StatTypes)i] + MonsterMakerManager.BASE_HEALTH;
                m_StatTypes_SLDRs[(StatTypes)i].value = MonsterMakerManager.BASE_HEALTH;
            }
            else
            {
                m_StatTypes_SLDRs[(StatTypes)i].value = MonsterMakerManager.BASE_STATS;
                m_StatTypes_TXTs[(StatTypes)i].text = m_stat_STRs[(StatTypes)i] + MonsterMakerManager.BASE_STATS;
            }
        }

        UpdateStatPoints();
    }

    public void UpdateStat(int statTypeI)
    {
        StatTypes statType = (StatTypes)statTypeI;
        int newAmount = (int)m_StatTypes_SLDRs[statType].value;

        MonsterMakerManager.ChangeStatAmount(newAmount, statType, out int changeAmount);
        m_StatTypes_SLDRs[statType].value -= changeAmount;
        string text = m_stat_STRs[statType] + m_StatTypes_SLDRs[statType].value;
        m_StatTypes_TXTs[statType].text = text;
    }

    public void UpdateStatPoints()
    {
        StatPoint_TXT.text = "Stat Points: " + MonsterMakerManager.StatPoints;
    }

    public void UpdateMonsterRarity(Int32 rarity)
    {
        rarity++;
        MonsterMakerManager.SetMonsterRarity((MonsterRarity)rarity);
        UpdateStatPoints();
    }

    public void UpdateMonsterType1(Int32 type)
    {
        MonsterMakerManager.CreatedMonster.MonsterType1 = (MonsterType)type;
    }

    public void UpdateMonsterType2(Int32 type)
    {
        MonsterMakerManager.CreatedMonster.MonsterType2 = (MonsterType)type;
    }

    public void UpdateMonsterElement1(Int32 type)
    {
        MonsterMakerManager.CreatedMonster.Element1 = (ElementType)type;
    }

    public void UpdateMonsterElement2(Int32 type)
    {
        MonsterMakerManager.CreatedMonster.Element2 = (ElementType)type;
    }
}
