using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CraftingRecipe/baseRecipe")]
public class CraftingRecipe : Item
{
    public Item result;
    public Ingredient[] ingredients;
    public float craftTime = 1f;
    private CraftingSlot parentCraftingSlot;

    public void SetParentSlot(CraftingSlot slot)
    {
        parentCraftingSlot = slot;
    }

    public bool CanCraft()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            bool containsCurrentIngredient = Inventory.instance.ContainsItem(ingredient.item, ingredient.amount);

            if (!containsCurrentIngredient)
            {
                return false;
            }
        }
        return true;
    }

    private void RemoveIngredientsFromInventory()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            Inventory.instance.RemoveItems(ingredient.item, ingredient.amount);
        }
    }

    public bool CraftItem()
    {
        if (!CanCraft())
        {
            return false;
        }

        RemoveIngredientsFromInventory();

        parentCraftingSlot.StartCrafting();

        return true;
    }

    public override void Use()
    {
        Inventory.instance.AddCraftingItem(this);
    }


    [System.Serializable]
    public class Ingredient
    {
        public Item item;
        public int amount;
    }
}
