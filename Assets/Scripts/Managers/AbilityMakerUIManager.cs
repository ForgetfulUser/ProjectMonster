using System.Collections.Generic;
using UnityEngine;


public class AbilityMakerUIManager : MonoBehaviour
{
    public GameObject SelfTargetContent_GO;
    public GameObject NonSelfTargetContent_GO;
    public BuffHolder BuffHolder_PRFB;
    
    public void DisplayBuffs(List<BuffData> selfTarget, List<BuffData> nonSelfTarget)
    {
        foreach(BuffData data in selfTarget)
        {
            BuffHolder holder = Instantiate(BuffHolder_PRFB, SelfTargetContent_GO.transform);
            holder.InitiateHolder(data, true);
        }

        foreach(BuffData data in nonSelfTarget)
        {
            BuffHolder holder = Instantiate(BuffHolder_PRFB, NonSelfTargetContent_GO.transform);
            holder.InitiateHolder(data, true);
        }
    }
}
