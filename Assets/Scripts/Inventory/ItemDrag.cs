using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private ItemSlot itemSlot;
    private Transform baseParent;
    private RectTransform hotbarRect;
    public int siblingIdx;
    public GameObject currentPreview;
    public Image image;



    void Start()
    {
        itemSlot = GetComponent<ItemSlot>();
        baseParent = transform.parent;
        //hotbarRect = GameManager.instance.hotbarTrna
        siblingIdx = transform.GetSiblingIndex();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(GameManager.instance.mainCanvas);
        itemSlot.OnCursorExit();
        itemSlot.isBeingDragged = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(baseParent);
        transform.SetSiblingIndex(siblingIdx);
        itemSlot.isBeingDragged = false;

        if (RectTransformUtility.RectangleContainsScreenPoint(hotbarRect, Input.mousePosition))
        {
            //Inventory.instance.SwitchHotbarInventory(itemSlot.item)
        }

        //Destroy(currentPreview);
    }
}
