using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public static Player instance { get; private set; }

    // this needs to be fired for results to show up on UI screen
    public event EventHandler OnFruitAmountChanged;

    public void BoughtItem(ShopItems.ShopItemType shopItemType)
    {
        // if bought, set the item on the player
    }

    public int GetFruitAmount()
    {
        return 0;
    }

    public int GetFruitType()
    {
        int type = 0;
        return type;
    }

    public bool TrySpendJuiceAmount(int spendJuiceAmount)
    {
      // if you have more gold than what the item is worth, spend it
      return false;
    }

    
    
}
