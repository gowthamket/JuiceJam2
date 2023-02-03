using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    private Item item;
    public bool isBeingDragged = false;

    public Item Item => item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
    }

    public void UseItem()
    {
        if (item == null || isBeingDragged == true)
        {
            return;
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
           
        }
        else
        {
            item.Use();
        }
    }

    public void OnCursorEnter()
    {

    }

    public void OnCursorExit()
    {

    }

    public void DestroySlot()
    {
        Destroy(gameObject);
    }
}
