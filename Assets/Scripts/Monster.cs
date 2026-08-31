using System;
using UnityEngine;

[Serializable]
public class Monster
{
    public Sprite Sprite;
    public string Name;
    [TextArea]
    public string Description;
    public Vector2 Health;
}
