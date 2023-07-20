using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<Item> items = new List<Item>();

    // Add a new item if enough room
    public void Add(Item item)
    {
        if (!item.showInInventory)
        {
            return;
        }

        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return;
        }

        // Check if the item already exists in the inventory
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == item.name)
            {
                items[i].count++;
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return;
            }
        }

        // Item doesn't exist in the inventory, add it
        items.Add(item);
        item.count = 1;
        item.durability = 5;
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
