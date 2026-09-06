using UnityEngine;

public class MonsterObject : MonoBehaviour
{
    [Header("Data")]
    public MonsterData MonsterData;
    // public MonsterAbilityData;

    [Header("Components")]
    public SpriteRenderer Sprite;

    public void InitiateMonster(MonsterData monsterData)
    {
        Sprite.sprite = monsterData.Sprite;
        // TODO: Load MonsterAbilityData for the monster
    }
}
