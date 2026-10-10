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
        RemovingBuffPanel
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
                GetComponent<Button>().onClick.AddListener(SelectAbilityPanelBuff);
                break;
            case HolderType.BuffMakerPanel:
                GetComponent<Button>().onClick.AddListener(SelectBuffMakerPanelBuff);
                break;
            case HolderType.AddBuffPanel:
                GetComponent<Button>().onClick.AddListener(SelectAddBuffPanelBuff);
                break;
            case HolderType.RemovingBuffPanel:
                GetComponent<Button>().onClick.AddListener(SelectRemoveBuffPanelBuff);
                break;
        }
    }

    public void SelectAbilityPanelBuff()
    {
        BuffDisplayerManager.Instance.SelectBuff(Buff);
    }

    public void SelectBuffMakerPanelBuff()
    {
        if (Buff.DoesTargetSelf)
        {
            AbilityMakerManager.Instance.SelectSelfTargetBuff(Buff);
        }
        else
        {
            AbilityMakerManager.Instance.SelectNonSelfTargetBuff(Buff);
        }
    }

    public void SelectAddBuffPanelBuff()
    {
        AddBuffManager.Instance.DisplayBuff(Buff);
    }

    public void SelectRemoveBuffPanelBuff()
    {

    }
}
