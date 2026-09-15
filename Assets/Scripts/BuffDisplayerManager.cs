using System.Collections.Generic;
using System;
using UnityEngine;

public class BuffDisplayerManager : MonoBehaviour
{
    public static BuffDisplayerManager Instance;
    public BuffData SelectedBuff;
    public BuffHolder BuffHolder_PRFB;
    public List<BuffHolder> Holders = new List<BuffHolder>();
    public Transform Content;

    private void Awake()
    {
        Instance = this;
    }

    public void StartDisplayer()
    {
        foreach (BuffHolder holder in Holders)
        {
            Destroy(holder.gameObject);
        }
        Holders.Clear();

        List<BuffData> buffs = BuffLoader.LoadAllBuffDatas(BuffLoader.BuffDataPath);
        if (buffs.Count == 0) Debug.Log("NO MONSTER");
        foreach (BuffData buff in buffs)
        {
            BuffHolder holder = Instantiate(BuffHolder_PRFB, Content);
            holder.InitiateHolder(buff);
            Holders.Add(holder);
        }

        SelectBuff(new BuffData());
        BuffDisplayerUIManager.Instance.SwapScreens();
    }

    public void SelectBuff(BuffData buffData)
    {
        SelectedBuff = buffData;
        BuffDisplayerUIManager.Instance.SelectMonster();
    }
}
