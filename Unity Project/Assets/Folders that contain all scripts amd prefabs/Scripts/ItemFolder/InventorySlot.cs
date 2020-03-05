using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; // image for showing the sprite of the item

    Items item; // Items script for creating item

    public void AddItem (Items newItem) // AddItem with the item as the paremeter
    {
        item = newItem; // add the new item to the index
        icon.sprite = item.icon; // change the image to the icon of the sprite
    }

    public void ClearSlot() // If there is a need to clear slot
    {
        item = null; // Set the item to null and clear the sprite
        icon.sprite = null;
    }
}
