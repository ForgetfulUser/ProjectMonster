using System.Collections.Generic;
using UnityEngine;


public class AbilityMakerUIManager : MonoBehaviour
{
    public GameObject AttachtedBuffsContent_GO;
    public BuffHolder BuffHolder_PRFB;
    public List<BuffHolder> BuffHolders = new List<BuffHolder>();

    public void DisplayBuffs()
    {
        foreach(BuffHolder holder in BuffHolders)
        {
            Destroy(holder.gameObject);
        }
        BuffHolders.Clear();

        List<BuffData> buffs = AbilityMakerManager.Instance.CreatedAbility.Buffs;
        foreach(BuffData data in buffs)
        {
            BuffHolder holder = Instantiate(BuffHolder_PRFB, AttachtedBuffsContent_GO.transform);
            holder.InitiateHolder(data, BuffHolder.HolderType.AddBuffPanel);
            BuffHolders.Add(holder);
        }
    }
}
