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

[SerializeField][Serializable]
public enum MonsterType
{
    None,
    Reptile,
    Fish,
    Dragon,
    Canine,
    Feline,
    Ghost,
    Elemental
}

[SerializeField][Serializable]
public enum ElementType
{
    None,
    Fire,
    Water,
    Earth,
    Air,
    Light,
    Dark
}
