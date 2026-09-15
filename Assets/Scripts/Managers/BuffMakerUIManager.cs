using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffMakerUIManager : MonoBehaviour
{
    public BuffMakerManager BuffMakerManager;
    public TMP_InputField Name_IF;
    public TMP_Dropdown AffectingStat_DRPDN;
    public TMP_Text AffectingStat_TXT;
    public Slider AffectingStat_SLDR;
    public TMP_Dropdown Condition_DRPDN;
    public TMP_Text Turns_TXT;
    public Slider Turns_SLDR;
    public TMP_InputField Desction_IF;

    private void Start()
    {
        Debug.Log(name);
        BuffMakerManager = BuffMakerManager.Instance;
        UpdateBuffUI();
    }

    public void UpdateBuffUI()
    {
        BuffData createdData = BuffMakerManager.CreatedBuff;// != null ? BuffMakerManager.CreatedBuff : new BuffData();

        if(createdData.Name != "Buff") 
        Name_IF.text = createdData.Name;
        
        AffectingStat_TXT.text = "Affecting Stat Amount: " + createdData.AffectingStatAmount;
        AffectingStat_SLDR.value = createdData.AffectingStatAmount;
        if(createdData.AffectingStat == StatType.MAX_STAT_TYPE)
            AffectingStat_DRPDN.value = 0;
        else
            AffectingStat_DRPDN.value = (int)createdData.AffectingStat + 1;


        Turns_TXT.text = "Turns Amount: " + createdData.MaxTurns;
        Turns_SLDR.value = createdData.MaxTurns;

        if (createdData.Condition == ConditionType.MAX_CONDITION_TYPE)
            Condition_DRPDN.value = 0;
        else Condition_DRPDN.value = (int)createdData.Condition + 1;

        Desction_IF.text = createdData.Description;
    }
}
