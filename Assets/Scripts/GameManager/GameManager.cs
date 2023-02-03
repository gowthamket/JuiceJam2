using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public List<Item> itemList = new List<Item> ();
    public List<Item> craftingRecipes = new List<Item> ();

    public Transform canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public Transform mainCanvas;
    public float moveX = 0f;
    public float moveY = 0f;    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Item newItem = itemList[Random.Range(0, itemList.Count)];
            Inventory.instance.AddItem(itemList[Random.Range(0, itemList.Count)]);
        }
    }

    public void OnStatItemUse(StatItemType itemType, int amount)
    {

    }
}
