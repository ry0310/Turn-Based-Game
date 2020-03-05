using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items item; // Get the item scriptable object

    void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item); // Add the item to the invertory scritp that contains the list of inventory
        Destroy(gameObject); // Destroy this object
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) // if player collided with this object
        {
            PickUp(); // call the pickup function
        }
    }
}
