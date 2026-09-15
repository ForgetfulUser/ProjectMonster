using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffMakerUIManager : MonoBehaviour
{
    public BuffMakerManager BuffMakerManager;
    public TMP_InputField Name_IF;
    public TMP_Dropdown AffectingStat_DRPDN;
    public TMP_Text AffectingStat_TXT;
    public TMP_Text Turns_TXT;
    public Slider Turns_SLDR;

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
        Turns_TXT.text = "Turns Amount: " + createdData.MaxTurns;
    }
}
