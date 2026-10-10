using System.Collections.Generic;
using UnityEngine;

public class AddBuffManager : MonoBehaviour
{
    public static AddBuffManager Instance;
    public AddBuffUIManager AddBuffUIManager;
    public GameObject BuffsToAddPanel_GO;
    public Transform BuffsContent_TRNSFM;
    public BuffHolder BuffHolder_PRFB;
    public List<BuffHolder> BuffHolders = new List<BuffHolder>();
    public List<BuffData> SelectedBuffs = new List<BuffData>();
    public BuffData DisplayingBuff;

    void Awake()
    {
        Instance = this;   
    }

    public void DisplayBuffs(List<BuffData> buffs)
    {
        foreach(BuffHolder holder in BuffHolders)
        {
            Destroy(holder.gameObject);
        }
        BuffHolders.Clear();

        foreach(BuffData buff in buffs)
        {
            BuffHolder buffHolder = Instantiate(BuffHolder_PRFB, BuffsContent_TRNSFM);
            buffHolder.InitiateHolder(buff, BuffHolder.HolderType.AddBuffPanel);
            BuffHolders.Add(buffHolder);
        }

        UpdateBuffHolders();
        DisplayBuff(null);
        BuffsToAddPanel_GO.SetActive(true);
    }

    public void DisplayBuff(BuffData buff)
    {
        DisplayingBuff = buff;
        AddBuffUIManager.DisplayBuff(buff);
    }

    public void SelectBuff(bool isSelecting)
    {
        if(isSelecting == true)
        {
            SelectedBuffs.Add(DisplayingBuff);
        }
        else
        {
            RemoveBuff();
            //SelectedBuffs.Remove(DisplayingBuff);
        }

        UpdateBuffHolders();

        AddBuffUIManager.DisplayBuff(DisplayingBuff);
    }

    private void RemoveBuff()
    {
        BuffData buffToRemove = DisplayingBuff;
        foreach(BuffData buff in SelectedBuffs)
        {
            if(buff.Name == DisplayingBuff.Name)
            {
                buffToRemove = buff;
                break;
            }
        }
        SelectedBuffs.Remove(DisplayingBuff);
    }

    public void UpdateBuffHolders()
    {
        foreach (BuffHolder holder in BuffHolders)
        {
            holder.Check_GO.SetActive(IsBuffAdded(holder.Buff));
        }
    }

    public void Complete()
    {
        AbilityMakerManager.Instance.UpdateBuffs(SelectedBuffs);
        Close();
    }

    public bool IsBuffAdded(BuffData buff)
    {
        bool buffIsAdded = false;
        foreach (BuffData _buff in SelectedBuffs)
        {
            if(_buff.Name == buff.Name)
            {
                buffIsAdded = true;
                break;
            }
        }
        return buffIsAdded;
    }

    public void Close()
    {
        BuffsToAddPanel_GO.SetActive(false);
        DisplayBuff(null);
    }
}
