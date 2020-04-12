using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<InventoryItem> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    private void OnValidate()
    {
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

            RefreshUI();
        }
    }//end OnValidate

    private void RefreshUI()
    {
        int i = 0;

        for(; i < items.Count && 1 < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];

        }//end for

        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;

        }//end for

    }//end RefreshUI

    public bool AddItem(InventoryItem item)
    {
        if (IsFull())
            return false;

        items.Add(item);
        RefreshUI();
        return true;
    }//end AddItem

    public bool RemoveItem(InventoryItem item)
    {
        if (items.Remove(item))
        {

            RefreshUI();
            return true;
        }//end if

        return false;

    }//end RemoveItem

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }//end isFull

}//end Inventory
