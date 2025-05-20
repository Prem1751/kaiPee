using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<Itemdata> inventoryList = new List<Itemdata>();

    public void AddItem(Itemdata item)
    {
        inventoryList.Add(item);
    }

    public int GetItemAmount(ItemBase data)
    {
        int amount = 0;
        foreach (Itemdata item in inventoryList)
        {
            if (item == data)
                amount++;
        }
        return amount;

    }

    internal int GetItemAmount(Itemdata targetItem)
    {
        throw new NotImplementedException();
    }
}