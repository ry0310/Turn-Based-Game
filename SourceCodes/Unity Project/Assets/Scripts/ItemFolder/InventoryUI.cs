using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; // Transform of the 
    public GameObject inventoryUI; // Gameobject containing UI
    Inventory inventory; // Reference the inventory script
    InventorySlot[] slots; // Get the slots in the grid layout of the slots

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance; // create an instance of the inventory
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); // Get the number of inventory slots
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); // if the I key is pressed, set the UI's active state to be different from the previous
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) // for loop for the number of slots
        {
            if (i < inventory.items.Count) // if the index is lesser than the number of items in the inventory
            {
                slots[i].AddItem(inventory.items[i]); // add the item to the inventory
            }
            else
            {
                slots[i].ClearSlot(); // if there is moer, clear the slot
            }
        }
    }
}