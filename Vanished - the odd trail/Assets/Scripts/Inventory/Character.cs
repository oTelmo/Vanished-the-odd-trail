using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<int> itemsID;

    public GameObject inventoryUIPrefab;
    public GameObject canvas;
    public GameObject hud;

    private GameObject inventoryUIObj;
    private InventoryUI inventoryUI;
    private Inventory inventory;

    private InventorySlotUI[] slotID;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        itemsID = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>().currentItemsID;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryUIObj == null)
            {
                inventoryUIObj = Instantiate(inventoryUIPrefab, canvas.transform);
                inventoryUI = inventoryUIObj.GetComponent<InventoryUI>();
                inventoryUI.InitializeInventoryUI(this, inventory);
                //inventoryUI.ClearInventoryUI();
                inventoryUI.UpdateInventoryUI();
            }
            else if (inventoryUIObj.activeSelf)
            {
                inventoryUIObj.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                inventoryUIObj.SetActive(true);
                //inventoryUI.ClearInventoryUI();
                inventoryUI.UpdateInventoryUI();
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(GameObject.FindWithTag("Bow"));
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemInstance itemInstance = other.gameObject.GetComponent<ItemInstance>();
        hud.GetComponent<HUD>().OpenMessagePanel("");
        if (itemInstance)
        {
                
            //add item to inventory
            inventory.AddItem(itemInstance.item);
            itemsID.Add(itemInstance.itemID);
            if (inventoryUI)
            {
                inventoryUI.ClearInventoryUI();
                inventoryUI.UpdateInventoryUI();
            }
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hud.GetComponent<HUD>().CloseMessagePanel();
    }
}
