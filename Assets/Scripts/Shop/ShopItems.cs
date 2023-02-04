using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/shopItem")]
public class ShopItems : Item
{
    public ShopItemType itemType;
    public int cost;

    public override void Use()
    {
        base.Use();
       
    }

    public enum ShopItemType
    {
        SpoonItem,
        WhiskItem,
        BlenderItem,
        HealthItem
    }
}
