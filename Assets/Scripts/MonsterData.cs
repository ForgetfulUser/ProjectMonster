using System;
using UnityEngine;

[Serializable]
public class MonsterData
{
    public Sprite Sprite;
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
}
