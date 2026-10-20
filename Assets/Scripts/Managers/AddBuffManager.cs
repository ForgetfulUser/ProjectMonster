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
    public List<string> SelectedBuffNames = new List<string>();
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
            SelectedBuffNames.Add(DisplayingBuff.Name);
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
        string buffToRemove = DisplayingBuff.Name;
        foreach(string name in SelectedBuffNames)
        {
            if(name == DisplayingBuff.Name)
            {
                buffToRemove = name;
                break;
            }
        }
        SelectedBuffNames.Remove(buffToRemove);
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
        AbilityMakerManager.Instance.ChangeBuffs(SelectedBuffNames);
        Close();
    }

    public bool IsBuffAdded(BuffData buff)
    {
        bool buffIsAdded = false;
        foreach (string buffName in SelectedBuffNames)
        {
            if(buffName == buff.Name)
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
