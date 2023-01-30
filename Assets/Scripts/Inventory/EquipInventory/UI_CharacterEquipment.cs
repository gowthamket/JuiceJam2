using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CharacterEquipment : MonoBehaviour
{
    [SerializeField] private Transform pfUI_Item;

    private Transform itemContainer;

    private UI_CharacterEquipmentSlot weaponSlot;
    private UI_CharacterEquipmentSlot helmetSlot;
    private UI_CharacterEquipmentSlot armorSlot;

    private CharacterEquipment characterEquipment;

    private void Awake()
    {
        weaponSlot = transform.Find("weaponSlot").GetComponent<UI_CharacterEquipmentSlot>();
        helmetSlot = transform.Find("helmetSlot").GetComponent<UI_CharacterEquipmentSlot>();
        armorSlot = transform.Find("armorSlot").GetComponent<UI_CharacterEquipmentSlot>();

        weaponSlot.OnItemDropped += WeaponSlot_OnItemDropped;
    }

    private void WeaponSlot_OnItemDropped(object sender, UI_CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        characterEquipment.TryEquipItem(CharacterEquipment.EquipSlot.Weapon, e.item);
    }

    private void SetCharacterEquipment(CharacterEquipment characterEquipment)
    {
        this.characterEquipment = characterEquipment;
        UpdateVisual();

        //characterEquipment.OnEquipmentChanged += CharacterEquipment_OnEquipmentChanged;
    }

    private void CharacterEquipment_OnEquipmentChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        Item weaponItem = characterEquipment.GetWeaponItem();
        if (weaponItem != null)
        {
            Transform uiItemTransform = Instantiate(pfUI_Item, itemContainer);
            uiItemTransform.GetComponent<RectTransform>().anchoredPosition = weaponSlot.GetComponent<RectTransform>().anchoredPosition;
            uiItemTransform.localScale = Vector3.one * 1.5f;
            uiItemTransform.GetComponent<CanvasGroup>().blocksRaycasts = true;
            UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
            //uiItem.SetItem(weaponItem);
            weaponSlot.transform.Find("emptyimage").gameObject.SetActive(false);
        }
        else
        {
            weaponSlot.transform.Find("emptyimage").gameObject.SetActive(true);
        }
    }
}
