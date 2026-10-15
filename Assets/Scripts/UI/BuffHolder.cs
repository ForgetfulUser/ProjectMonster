using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffHolder : MonoBehaviour
{
    public enum HolderType
    {
        AbilityMakerPanel,
        BuffMakerPanel,
        AddBuffPanel,
        AbilityDisplayerPanel
    }

    public BuffData Buff;
    public TMP_Text Text;
    public HolderType holderType;
    public GameObject Check_GO;

    public void InitiateHolder(BuffData buff, HolderType holderType)
    {
        Buff = buff;
        Text.text = Buff.Name;
        this.holderType = holderType;

        switch (holderType)
        {
            case HolderType.AbilityMakerPanel:
                GetComponent<Button>().onClick.AddListener(SelectAbilityMakerPanelBuff);
                break;
            case HolderType.AbilityDisplayerPanel:
                GetComponent<Button>().onClick.AddListener(SelectAbilityDisplayerPanelBuff);
                break;
            case HolderType.BuffMakerPanel:
                GetComponent<Button>().onClick.AddListener(SelectBuffMakerPanelBuff);
                break;
            case HolderType.AddBuffPanel:
                GetComponent<Button>().onClick.AddListener(SelectAddBuffPanelBuff);
                break;
        }
    }

    public void SelectAbilityMakerPanelBuff()
    {
        AbilityMakerManager.Instance.SelectBuff(Buff);
    }

    public void SelectAbilityDisplayerPanelBuff()
    {
        AbilityDisplayerManager.Instance.SelectBuff(Buff);
    }

    public void SelectBuffMakerPanelBuff()
    {
        BuffDisplayerManager.Instance.SelectBuff(Buff);
    }

    public void SelectAddBuffPanelBuff()
    {
        AddBuffManager.Instance.DisplayBuff(Buff);
    }
}
