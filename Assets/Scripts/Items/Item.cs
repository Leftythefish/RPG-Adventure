using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool used;

    public Interactable interactable;

    public virtual void Use()
    {
        //Use item
        //is overwritten by inheriting item class, check references.
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}

