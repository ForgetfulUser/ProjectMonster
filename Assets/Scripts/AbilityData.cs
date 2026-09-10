using UnityEngine;

public struct BuffData
{
    public int StatBuffAmount;
    public StatTypes BuffingStat;


}

public class AbilityData : MonoBehaviour
{
    public string Name;
    public string Description;
    public int Damage;
    //public List<BuffData> Buffs = new List<BuffData>();
}
