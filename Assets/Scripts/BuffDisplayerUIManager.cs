using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffDisplayerUIManager : MonoBehaviour
{
    public static BuffDisplayerUIManager Instance;
    public GameObject Displayer_GO;
    public GameObject Maker_GO;

    [Header("Selected Monster Stuff")]
    public Image Sprite_IMG;
    public TMP_Text Name_TXT;
    public TMP_Text Description_TXT;
    public TMP_Text AffectingStat_TXT;
    public TMP_Text Condition_TXT;
    public TMP_Text TurnsAmount_TXT;

    private void Awake()
    {
        Instance = this;
    }

    public void SwapScreens()
    {
        Displayer_GO.SetActive(!Displayer_GO.activeSelf);
        Maker_GO.SetActive(!Maker_GO.activeSelf);
    }

    public void SelectMonster()
    {
        BuffData buff = BuffDisplayerManager.Instance.SelectedBuff;
        Sprite_IMG.sprite = buff.Sprite;

        Name_TXT.text = buff.Name;
        Description_TXT.text = buff.Description;

        string stat_TXT = "";
        switch (buff.AffectingStat)
        {
            case StatType.Health:
                stat_TXT = "Health";
                break;
            case StatType.PhysicalAttack:
                stat_TXT = "Physical Attack";
                break;
            case StatType.MagicalDefense:
                stat_TXT = "Physical Defense";
                break;
            case StatType.MagicalAttack:
                stat_TXT = "Magical Attack";
                break;
            case StatType.PhysicalDefense:
                stat_TXT = "Magical Defense";
                break;
            case StatType.Speed:
                stat_TXT = "Speed";
                break;
        }
        if (buff.AffectingStat != StatType.MAX_STAT_TYPE)
            AffectingStat_TXT.text = stat_TXT + ": " + buff.AffectingStatAmount;
        else
            AffectingStat_TXT.text = "No stat change";

        if (buff.Condition != ConditionType.MAX_CONDITION_TYPE)
            Condition_TXT.text = buff.Condition.ToString();
        else
            Condition_TXT.text = "No Condition";

        TurnsAmount_TXT.text = "Turns Amount: " + buff.MaxTurns;
    }
}
