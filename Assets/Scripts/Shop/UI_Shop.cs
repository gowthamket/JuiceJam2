using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer customer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = transform.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        //CreateItemButton(Item.GetSprite(Item.ItemType.Armor_1), )

        Hide();
    }

    private void CreateItemButton(ShopItems.ShopItemType shopItemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        TryBuyItem(shopItemType);
    }

    public void TryBuyItem(ShopItems.ShopItemType shopItemType)
    {
        // if customer could afford gold amount, buy item
        customer.BoughtItem(shopItemType);
        //else warn they cannot afford
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.customer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    
}
