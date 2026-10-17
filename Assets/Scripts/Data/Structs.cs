using System;
using System.Numerics;

[Serializable]
public struct SearchParameter
{
    public string Name;
    public MonsterType MonsterType1;
    public MonsterType MonsterType2;
    public Vector2 RarityMinMax;
    public ElementType Element1;
    public ElementType Element2;

    public Vector2 PhysAtkMinMax;
    public Vector2 PhyDefMinMax;
    public Vector2 MagAtkMinMax;
    public Vector2 MagDefMinMax;
    public Vector2 SpeedMinMax;
}
