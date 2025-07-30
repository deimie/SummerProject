using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] int balance;

    [Header("Items")]
    [SerializeField] ItemSO[] items;
    [SerializeField] List<ItemSO> shoppingCart;
    ItemSO item;
    
    [Header("Transform")]
    Transform container;
    Transform shopItemTemplate;

    void Awake()
    {
        //shopItemTemplate = container.Find("shopItemTemplate");
    }

    void Start()
    {
        gameObject.SetActive(false);
        PopulateShop();
    }

    void PopulateShop()
    {
        for (int i = 0; i < items.Length; i++)
        {
            Debug.Log("Item Name: " + items[i].GetItemName() + ", Item Cost: " + items[i].GetItemCost());
            // createButton();
        }
    }

    void BuyItem()
    {
        if (balance >= item.GetItemCost())
        {
            balance -= item.GetItemCost();
            Debug.Log("Bought item: " + item.GetItemName());
        }
        else
        {
            Debug.Log("Insufficient Funds");
        }

        shoppingCart.Add(item);
    }
}
