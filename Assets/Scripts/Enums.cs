using System;
using UnityEngine;


[SerializeField][Serializable]
public enum StatTypes
{
    Health,
    PhysicalAttack,
    PhysicalDefense,
    MagicalAttack,
    MagicalDefense,
    Speed,
    MAX_STAT_TYPE
}

[SerializeField][Serializable]
public enum MonsterRarity
{
    UnusedMonsterRarity,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic,
    Ancient
}
