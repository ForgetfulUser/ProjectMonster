using UnityEngine;
using TMPro;

public class MonsterHolder : MonoBehaviour
{
    MonsterDisplayerUIManager MonsterDisplayerUIManager;
    public MonsterData Monster;
    public TMP_Text Text;

    public void InitiateHolder(MonsterData monster)
    {
        Monster = monster;
        Text.text = Monster.Name;
    }

    public void SelectMonster()
    {
        MonsterDisplayerUIManager.Instance.SelectMonster(Monster);
    }
}
