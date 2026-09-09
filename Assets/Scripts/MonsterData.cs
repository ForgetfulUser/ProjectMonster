using System;
using UnityEngine;

[Serializable]
public class MonsterData
{
    public string MonsterID;
    public Sprite Sprite;
    public MonsterRarity MonsterRarity;
    public MonsterType MonsterType1;
    public MonsterType MonsterType2;
    public ElementType Element1;
    public ElementType Element2;
    public string Name = "Monster";
    [TextArea]
    public string Description = "Description";
    public Vector2Int Health;
    public int TempHealth = 0;
    public int Accuracy = 100;

    public int PhysicalAttack;
    public int MagicalAttack;
    public int PhysicalDefense;
    public int MagicalDefense;
    public int Speed;

    public bool IsNewer;
}
