using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    // remember this for when you are optimizing the project
    public HashSet<Item> allItems = new HashSet<Item>();

    public int space = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    #region Singleton

    public static Inventory Instance = new Inventory();

    public void Awake()
    {
        if (Instance != null)
        {
            
        }

        Instance = this;
    }

    #endregion
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
