using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

[Serializable]
public class BuffData
{
    public string ID;
    public string Name = "Buff";
    public string Description;
    public Sprite Sprite;
    public int MaxTurns;
    public int TurnsTaken;
    public bool DoesTargetSelf;
    public StatType AffectingStat = StatType.MAX_STAT_TYPE;
    public int AffectingStatAmount;
    public ConditionType Condition = ConditionType.MAX_CONDITION_TYPE;

    public void LoadBuff()
    {
        string spritePath = "Sprites/Abilities/" + Name;
        Sprite = Resources.Load<Sprite>(spritePath);
    }
}

[Serializable]
public class AbilityData
{
    public string ID;
    public string Name = "Ability";
    [TextArea]
    public string Description = "Description";
    public int Damage;
    public bool DoesTargetSelf;
    public Sprite Sprite;
    public RarityType MonsterRarity;
    public MonsterType MonsterType;
    public ElementType Element;
    public List<BuffData> Buffs = new List<BuffData>();
    public List<string> BuffNames = new List<string>();

    public void LoadAbility()
    {
        Buffs.Clear();
        foreach(string name in BuffNames)
        {
            Buffs.Add(BuffLoader.LoadBuffByName(name));
        }
        string spritePath = "Sprites/Abilities/" + Name;
        Sprite = Resources.Load<Sprite>(spritePath);
    }
}
