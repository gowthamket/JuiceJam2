using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer 
{
    void BoughtItem(ShopItems.ShopItemType type);
    bool TrySpendJuiceAmount(int juiceAmount);
}
