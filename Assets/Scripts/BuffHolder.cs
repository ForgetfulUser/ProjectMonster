using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffHolder : MonoBehaviour
{
    public BuffData Buff;
    public TMP_Text Text;

    public void InitiateHolder(BuffData buff, bool isForAbility)
    {
        Buff = buff;
        Text.text = Buff.Name;
        if(!isForAbility)
            GetComponent<Button>().onClick.AddListener(SelectBuff);
        else
            GetComponent<Button>().onClick.AddListener(SelectAbilityBuff);
    }

    public void SelectBuff()
    {
        BuffDisplayerManager.Instance.SelectBuff(Buff);
    }

    public void SelectAbilityBuff()
    {
        if (Buff.DoesTargetSelf)
        {
            AbilityMakerManager.Instance.SelectSelfTargetBuff(Buff);
        }
        else
        {
            AbilityMakerManager.Instance.SelectNonSelfTargetBuff(Buff);
        }

        GetComponent<Button>().Select();
    }
}
