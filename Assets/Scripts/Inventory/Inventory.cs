using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region singleton

    public static Inventory instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate { };

    public List<Item> inventoryItemList = new List<Item>();

    private Queue<CraftingRecipe> craftingQueue = new Queue<CraftingRecipe> ();
    private bool isCrafting;

    public void AddItem(Item item)
    {
        inventoryItemList.Add(item);
        onItemChange.Invoke();
    }

    public void RemoveItem(Item item)
    {
        inventoryItemList.Remove(item);
        onItemChange.Invoke();
    }

    public bool ContainsItem(Item item, int amount)
    {
        int itemCounter = 0;

        foreach (Item i in inventoryItemList)
        {
            if (i == item)
            {
                itemCounter++;
            }
        }

        if (itemCounter >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveItems(Item item, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            RemoveItem(item);
        }
    }

    public void RemoveItemType(string itemName)
    {
        foreach (Item i in inventoryItemList)
        {
            if (i.name == itemName)
            {
                inventoryItemList.Remove(i);
            }
        }
    }

    public void AddCraftingItem(CraftingRecipe newRecipe)
    {
        craftingQueue.Enqueue(newRecipe);

        if (!isCrafting)
        {
            isCrafting = true;
            StartCoroutine(CraftItem());
        }
    }

    private IEnumerator CraftItem()
    {
        if (craftingQueue.Count == 0)
        {
            isCrafting = false;
            yield break;
        }

        CraftingRecipe currentRecipe = craftingQueue.Dequeue();

        if (currentRecipe.CraftItem())
        {
            craftingQueue.Clear();
            isCrafting = false;
            yield break;
        }

        yield return new WaitForSeconds(currentRecipe.craftTime * 1.1f);

        AddItem(currentRecipe.result);

        if (craftingQueue.Count > 1)
        {
            yield return StartCoroutine(CraftItem());
        }
    }
    
}
