using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : ItemSlot
{
    public GameObject craftingImageGO;
    private Image craftingImage;
    private float crafTime;

    public override void AddItem(Item newItem)
    {
        base.AddItem(newItem);
        craftingImage = craftingImageGO.GetComponent<Image>();
        craftingImage.sprite = newItem.icon;
        craftingImageGO.SetActive(false);
        crafTime = ((CraftingRecipe)newItem).craftTime;
    }

    public void StartCrafting()
    {
        if (gameObject.activeInHierarchy == true)
        {

        }
    }
}
