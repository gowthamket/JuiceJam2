using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/statItem")]
public class StatItem : Item
{
    public StatItemType itemType;
    public int amount;

    public override void Use()
    {
        base.Use();
        GameManager.instance.OnStatItemUse(itemType, amount);
        Inventory.instance.RemoveItem(this);
    }

    
}

public enum StatItemType
{
    HealthItem,
    ThirstItem,
    FoodItem
}

