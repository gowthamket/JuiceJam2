using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private const float SPEED = 50f;

    //[SerializeField] private MaterialTintColor materialTintColor;

    //private Player_Base player;
    //private State state;

    public event EventHandler OnGoldAmountChanged;
    public event EventHandler OnHealthPotionAmountChanged;
    public event EventHandler OnEquipChanged;

    private Inventory inventory;

    //[SerializeField] private MaterialTintColor
    [SerializeField] private UI_Inventory uiInventory;

    private void Awake()
    {
        Instance = this;

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(20, 20), new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(-20, 20), new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(0, -20), new Item { itemType = Item.ItemType.Sword, amount = 1 });
    }

    public void UseItem(Item inventoryItem)
    {
        Debug.Log("Use Item: " + inventoryItem);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public void SetEquipment(Item item)
    {
        SetEquipment(item.itemType);
    }

    public void SetEquipment(Item.ItemType itemType)
    {
        // Equip Item
        switch (itemType)
        {
            //case Item.ItemType.ArmorNone: EquipArmorNone(); break;
            //case Item.ItemType.Armor_1: EquipArmor_1(); break;
            //case Item.ItemType.Armor_2: EquipArmor_2(); break;

            //case Item.ItemType.HelmetNone: EquipHelmetNone(); break;
            //case Item.ItemType.Helmet: EquipHelmet(); break;

            //case Item.ItemType.SwordNone: EquipWeapon_Punch(); break;
            //case Item.ItemType.Sword_1: EquipWeapon_Sword(); break;
            //case Item.ItemType.Sword_2: EquipWeapon_Sword2(); break;
        }
        OnEquipChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
        }
    }
}
