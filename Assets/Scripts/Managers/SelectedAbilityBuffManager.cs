using UnityEngine;

public class SelectedAbilityBuffManager : MonoBehaviour
{
    public SelectedAbilityBuffUIManager SelectedAbilityBuffUIManager;
    public BuffData SelectedBuff;

    public void SelectBuff(BuffData buff)
    {
        SelectedBuff = buff;
        SelectedAbilityBuffUIManager.UpdateSelectedBuff(SelectedBuff);
    }
}
