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
    public MonsterData CreatedMonster;
    public int Points;

    public void TakeName(string _name)
    {
        CreatedMonster.Name = _name;
    }

    public void TakeDescription(string desc)
    {
        CreatedMonster.Description = desc;
    }

    public bool TakeAmount(Single amount, StatTypes statTypes)
    {
        int pointChangeAmount = 0;

        switch (statTypes)
        {
            case StatTypes.Health:
                pointChangeAmount = (int)amount - CreatedMonster.Health.y;
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

        /*
        if(Points - pointChangeAmount < 0)
        {
            return false;
        }
        else
        {
            Points -= pointChangeAmount;
        }
        */

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

        return true;
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
}
