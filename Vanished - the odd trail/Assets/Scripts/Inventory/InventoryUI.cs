using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI[] itemSlotsUI;
    private PlayerInventory ownerCharacter;
    private Inventory inventory;

    private GameObject hand;
    public List<int> itemsID;
    public Transform[] items;
    private InventoryManager inventoryManager;

    private void Start()
    {
        hand = GameObject.FindWithTag("Hand");
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>();
        itemsID = inventoryManager.currentItemsID;
    }

    public void InitializeInventoryUI(PlayerInventory c, Inventory i)
    {
        ownerCharacter = c;
        inventory = i;
        foreach(InventorySlotUI slot in itemSlotsUI)
        {
            slot.itemButton.onClick.AddListener(delegate{FindCurrentSlot(slot.id);});
        }
    }

    public void ClearInventoryUI()
    {
        foreach(InventorySlotUI slot in itemSlotsUI)
        {
            slot.itemImage.sprite = null;
        }
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            itemSlotsUI[i].itemImage.sprite = inventory.inventory[i].item.GetIcon();
        }
    }

    private void FindCurrentSlot(int slotID)
    {
        foreach(int itemid in itemsID)
        {
            if (itemid == slotID)
            {
                foreach (Transform child in hand.transform)
                {
                    int itemID = child.GetComponent<ItemManager>().id;
                    if (itemID == slotID)
                    {
                        inventoryManager.currentItem = child.gameObject;
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
