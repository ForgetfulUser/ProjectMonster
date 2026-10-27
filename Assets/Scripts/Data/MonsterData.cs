using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterData
{
    public static string BaseName = "New Monster";

    public string MonsterID;
    public Sprite Sprite;
    public RarityType MonsterRarity = RarityType.Common;
    public MonsterType MonsterType1;
    public MonsterType MonsterType2;
    public ElementType Element1;
    public ElementType Element2;
    public string Name = BaseName;
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

    public List<AbilityData> Abilities = new List<AbilityData>();
    public List<string> AbilityNames = new List<string>();

    public bool IsNewer;

    public void LoadMonster()
    {
        Abilities.Clear();
        foreach(string name in AbilityNames)
        {
            AbilityData data = AbilityLoader.LoadAbilityByName(name);
            data.LoadAbility();
            Abilities.Add(data);
        }
        string spritePath = "Sprites/Monsters/" + Name;
        Sprite = Resources.Load<Sprite>(spritePath);
    }
}
