using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
}

[CreateAssetMenu]
public class EquippableItem : InventoryItem
{
    public int Defense;
    public int Attack;
    [Space]
    public EquipmentType EquipmentType;
    
}
