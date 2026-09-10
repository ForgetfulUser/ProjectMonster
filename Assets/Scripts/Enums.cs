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
    None,
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
    Elemental,
    Plant
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


