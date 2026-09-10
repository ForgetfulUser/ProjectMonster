using System;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    public TMP_Dropdown MonsterRarity_DRPDN;
    public TMP_Dropdown MonsterType1_DRPDN;
    public TMP_Dropdown MonsterType2_DRPDN;
    public TMP_Dropdown MonsterElement1_DRPDN;
    public TMP_Dropdown MonsterElement2_DRPDN;

    public TMP_InputField Description_IF;

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
    }

    public void UpdateWithMonster(MonsterData monster)
    {
        MonsterName_IF.text = monster.Name; // Set Name

        int rarityValue = /*monster.MonsterRarity == MonsterRarity.Legendary ? (int)monster.MonsterRarity :*/ (int)monster.MonsterRarity - 1;
        MonsterRarity_DRPDN.value = rarityValue; // Set Rarity

        // Set Types
        MonsterType1_DRPDN.value = (int)monster.MonsterType1;
        MonsterType2_DRPDN.value = (int)monster.MonsterType2;

        // Set Elements
        MonsterElement1_DRPDN.value = (int)monster.Element1;
        MonsterElement2_DRPDN.value = (int)monster.Element2;

        // Set Stat Slider Values & Text
        for(int i = 0; i < (int)StatTypes.MAX_STAT_TYPE; i++)
        {
            StatTypes statType = (StatTypes)i;

            switch(statType)
            {
                case StatTypes.Health:
                    m_StatTypes_SLDRs[statType].value = monster.Health.y;
                    break;
                case StatTypes.PhysicalAttack:
                    m_StatTypes_SLDRs[statType].value = monster.PhysicalAttack;
                    break;
                case StatTypes.PhysicalDefense:
                    m_StatTypes_SLDRs[statType].value = monster.PhysicalDefense;
                    break;
                case StatTypes.MagicalAttack:
                    m_StatTypes_SLDRs[statType].value = monster.MagicalAttack;
                    break;
                case StatTypes.MagicalDefense:
                    m_StatTypes_SLDRs[statType].value = monster.MagicalDefense;
                    break;
                case StatTypes.Speed:
                    m_StatTypes_SLDRs[statType].value = monster.Speed;
                    break;
            }

            string text = m_stat_STRs[statType] + m_StatTypes_SLDRs[statType].value;
            m_StatTypes_TXTs[statType].text = text;
        }
        
        Description_IF.text = monster.Description; // Set Description

        UpdateStatPoints();
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
