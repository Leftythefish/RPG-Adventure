﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;

        if (item.name == "Key" || item.name == "Crystal Fragment" || item.name == "Fishing Rod")
        {
            removeButton.interactable = false;
        }
        else
        {
            removeButton.interactable = true;
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null && item.name != "Key" && item.name != "Crystal Fragment")
        {
            item.Use();
        }
    }
}
