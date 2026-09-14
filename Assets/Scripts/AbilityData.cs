using UnityEngine;
using System.Collections.Generic;

public class BuffData
{
    public string ID;
    public string Name;
    public Sprite Sprite;
    public int MaxTurns;
    public int Turns;
    public StatType BuffingStat;
    public int StatBuffAmount;


}

public class AbilityData : MonoBehaviour
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
