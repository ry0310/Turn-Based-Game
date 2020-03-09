using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Singleton for the inventory instance.
    #region  

    public static Inventory instance;

    void Awake()
    {
        if (instance != null) // If there is another instance
        {
            Debug.LogWarning("More than one instance is active");
            return; // Give a warning and do nothing
        }
        instance = this; // If there isn't, uses this instance
    }
    #endregion

    public delegate void OnItemChanged(); // a function that can be used as a variable
    public OnItemChanged onItemChangedCallback;

    public int space = 20; // maximum slots for the inventory UI

    public List<Items> items = new List<Items>(); // List of the items

    public bool Add (Items item) // Add the item
    {
        if (!item.isDefaultItem) // If the item is not a default item
        {
            if(items.Count >= space) // And if there is no space
            {
                Debug.Log("Not enough room."); // Give a warning and do nothing
                return false;
            }
            items.Add(item); // If there is slots, add the item

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove(Items item)
    {
        items.Remove(item); // Remove the item

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}