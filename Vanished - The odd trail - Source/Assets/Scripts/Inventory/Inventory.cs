using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<InventorySlot> inventory;
    public int maxSlots = 5;

    public Inventory()
    {
        inventory = new List<InventorySlot>();
    }

    public void AddItem(Item item)
    {
        bool found = false;
        foreach(InventorySlot slot in inventory)
        {
            if (item.GetType() == slot.item.GetType())
            {
                found = true;
                break;
            }
        }
        if(!found)
        {
            if(inventory.Count < maxSlots)
            {
                inventory.Add(new InventorySlot(item));
            }
        }
        
    }
}
