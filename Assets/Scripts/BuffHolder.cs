using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffHolder : MonoBehaviour
{
    public BuffData Buff;
    public TMP_Text Text;

    public void InitiateHolder(BuffData buff)
    {
        Buff = buff;
        Text.text = Buff.Name;
        GetComponent<Button>().onClick.AddListener(SelectBuff);
    }

    public void SelectBuff()
    {
        BuffDisplayerManager.Instance.SelectBuff(Buff);
    }
}
