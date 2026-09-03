using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterMakerUIManager : MonoBehaviour
{
    public MonsterMakerManager MonsterMakerManager;

    [Header("Text")]
    public TMP_Text Health_TXT;
    public TMP_Text PhysicalAttack_TXT;
    public TMP_Text MagicalAttack_TXT;
    public TMP_Text PhysicalDefense_TXT;
    public TMP_Text MagicalDefense_TXT;
    public TMP_Text Speed_TXT;

    [Header("Slider")]
    public Slider Health_SLDR;


    private void Start()
    {
        UpdateHealth(15);
        UpdatePhysicalAttack(5);
        UpdatePhysicalDefense(5);
        UpdateMagicalAttack(5);
        UpdateMagicalDefense(5);
        UpdateSpeed(5);
    }

    public void UpdateHealth(Single amount)
    {
        MonsterMakerManager.TakeAmount(amount, StatTypes.Health);
        Health_TXT.text = "Max Health: " + amount;
    }
    
    public void UpdatePhysicalAttack(Single amount)
    {
        MonsterMakerManager.TakeAmount(amount, StatTypes.PhysicalAttack);
        PhysicalAttack_TXT.text = "Phys. Attack: " + amount;
    }
    
    public void UpdatePhysicalDefense(Single amount)
    {
        MonsterMakerManager.TakeAmount(amount, StatTypes.PhysicalDefense);
        PhysicalDefense_TXT.text = "Phys. Defense: " + amount;
    }
    
    public void UpdateMagicalAttack(Single amount)
    {
        MonsterMakerManager.TakeAmount(amount, StatTypes.MagicalAttack);
        MagicalAttack_TXT.text = "Mag. Attack: " + amount;
    }
    
    public void UpdateMagicalDefense(Single amount)
    {
        MonsterMakerManager.TakeAmount(amount, StatTypes.MagicalDefense);
        MagicalDefense_TXT.text = "Mag. Defense: " + amount;
    }
    
    public void UpdateSpeed(Single amount)
    {
        MonsterMakerManager.TakeAmount(amount, StatTypes.Speed);
        Speed_TXT.text = "Speed: " + amount;
    }
}
