using UnityEngine;
using System.Collections.Generic;

public class BuffData
{
    public string ID;
    public string Name = "Buff";
    public string Description;
    public Sprite Sprite;
    public int MaxTurns;
    public int Turns;
    public StatType AffectingStat = StatType.MAX_STAT_TYPE;
    public int AffectingStatAmount;
    public ConditionType Condition = ConditionType.MAX_CONDITION_TYPE;

}

public class AbilityData
{
    public string ID;
    public string Name = "Ability";
    [TextArea]
    public string Description = "Description";
    public int Damage;
    public Sprite Sprite;
    public MonsterType MonsterType;
    public ElementType Element;
    public List<BuffData> OwnerBuffs = new List<BuffData>();
    public List<BuffData> EnemyBuffs = new List<BuffData>();
}
