using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonsterMakerManager : MonoBehaviour
{
    public GameObject MakerPanel;
    public MonsterDisplayerUIManager MonsterDisplayerUIManager;
    public MonsterMakerUIManager MonsterMakerUIManager;
    public MonsterData CreatedMonster;
    public int StatPoints;

    public const int BASE_HEALTH = 15;
    public const int BASE_STATS = 5;

    public List<int> StatPoints_LST = new List<int>();
    public Dictionary<MonsterRarity, int> StatPoints_DIC = new Dictionary<MonsterRarity, int>();

    private void Start()
    {
        SetBasicStats();

        for(int i = 0; i <= (int)MonsterRarity.Ancient; i++)
        {
            StatPoints_DIC.Add((MonsterRarity)i, StatPoints_LST[i]);
        }
    }

    public void TakeName(string _name)
    {
        CreatedMonster.Name = _name;
    }

    public void TakeDescription(string desc)
    {
        CreatedMonster.Description = desc;
    }

    public void ChangeStatAmount(Single amount, StatTypes statTypes, out int changeAmount)
    {
        changeAmount = 0;

        // Generate pointChangeAmount by StatType
        switch (statTypes)
        {
            case StatTypes.Health:
                changeAmount = (int)amount - CreatedMonster.Health.y;
                break;
            case StatTypes.PhysicalAttack:
                changeAmount = (int)amount - CreatedMonster.PhysicalAttack;
                break;
            case StatTypes.PhysicalDefense:
                changeAmount = (int)amount - CreatedMonster.PhysicalDefense;
                break;
            case StatTypes.MagicalAttack:
                changeAmount = (int)amount - CreatedMonster.MagicalAttack;
                break;
            case StatTypes.MagicalDefense:
                changeAmount = (int)amount - CreatedMonster.MagicalDefense;
                break;
            case StatTypes.Speed:
                changeAmount = (int)amount - CreatedMonster.Speed;
                break;
        }

        // If there's remaining StatPoints, increase. Else, return pointChangeAmount
        if (StatPoints - changeAmount >= 0)
        {
            StatPoints -= changeAmount;
            changeAmount = 0; // Reset Change Amount to 0 on success
        }
        else
        {
            // Return early for failure
            return;
        }

        // Change the created monsters stat
        switch (statTypes)
        {
            case StatTypes.Health:
                CreatedMonster.Health = new Vector2Int((int)amount, (int)amount);
                break;
            case StatTypes.PhysicalAttack:
                CreatedMonster.PhysicalAttack = (int)amount;
                break;
            case StatTypes.PhysicalDefense:
                CreatedMonster.PhysicalDefense = (int)amount;
                break;
            case StatTypes.MagicalAttack:
                CreatedMonster.MagicalAttack = (int)amount;
                break;
            case StatTypes.MagicalDefense:
                CreatedMonster.MagicalDefense = (int)amount;
                break;
            case StatTypes.Speed:
                CreatedMonster.Speed = (int)amount;
                break;
        }
    }

    public void SetMonsterRarity(MonsterRarity monsterRarity)
    {
        CreatedMonster.MonsterRarity = monsterRarity;

        // Set new Stat Points
        StatPoints = StatPoints_DIC[monsterRarity];

        // Add stat points for minmum stats
        StatPoints += (BASE_STATS * 5) + 15;

        // Removed statpoints based on current stats
        StatPoints -= CreatedMonster.Health.y;
        StatPoints -= CreatedMonster.PhysicalAttack;
        StatPoints -= CreatedMonster.PhysicalDefense;
        StatPoints -= CreatedMonster.MagicalAttack;
        StatPoints -= CreatedMonster.MagicalDefense;
        StatPoints -= CreatedMonster.Speed;

        // If too many stat points have been used, reset monster stats and StatPoints
        if (StatPoints < 0)
        {
            SetBasicStats();
            MonsterMakerUIManager.SetBaseStats();
            StatPoints = StatPoints_DIC[monsterRarity];
        }
    }

    public void SaveMonster()
    {
        if (CreatedMonster.Name == "Monster")
        {
            Debug.Log("Rename Monster");
            return;
        }
        MonsterLoader.SaveMonster(CreatedMonster);
        SceneManager.LoadScene("Monster Maker Scene");
    }

    public void OpenCreatedMonsters()
    {
        List<MonsterData> monsters = MonsterLoader.LoadAllMonsterDatas(MonsterLoader.MonsterDataPath);
        if (monsters.Count == 0) Debug.Log("NO MONSTER");
        MakerPanel.SetActive(false);
        MonsterDisplayerUIManager.StartDisplayer(monsters);
    }

    public void SetBasicStats()
    {
        CreatedMonster.Health = new Vector2Int(BASE_HEALTH, BASE_HEALTH);
        CreatedMonster.PhysicalAttack = BASE_STATS;
        CreatedMonster.PhysicalDefense = BASE_STATS;
        CreatedMonster.MagicalAttack = BASE_STATS;
        CreatedMonster.MagicalDefense = BASE_STATS;
        CreatedMonster.Speed = BASE_STATS;
    }
}
