using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject // scriptable object for creating item, containing name and sprite
{
    new public string name = "new Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
