using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite swordSprite;
    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite coinSprite;
    public Sprite medkitSprite;
    public Sprite s_Sword_1;
    public Sprite s_Sword_2;
    public Sprite s_ArmorNone;
    public Sprite s_Armor_1;
    public Sprite s_Armor_2;
    public Sprite s_HelmetNone;
    public Sprite s_Helmet;
}
