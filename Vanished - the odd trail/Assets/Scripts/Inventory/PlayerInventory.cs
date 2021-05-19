using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<int> itemsID;

    public GameObject inventoryUIPrefab;
    public GameObject canvas;
    public GameObject hud;

    private GameObject inventoryUIObj;
    private InventoryUI inventoryUI;
    private Inventory inventory;
    private PlayerMovement playerMovement;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>();
        itemsID = inventoryManager.currentItemsID;
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerMovement.LockPlayerMovement(true);
            inventoryManager.inventoryOpen = true;
            Cursor.lockState = CursorLockMode.None;
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
                playerMovement.UnLockPlayerMovement();
                inventoryManager.inventoryOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                inventoryUIObj.SetActive(true);
                //inventoryUI.ClearInventoryUI();
                inventoryUI.UpdateInventoryUI();
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemInstance itemInstance = other.gameObject.GetComponent<ItemInstance>();
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

    public void InventoryAddItem(int itemID, Item item)
    {
        inventory.AddItem(item);
        itemsID.Add(itemID);
        if (inventoryUI)
        {
            inventoryUI.ClearInventoryUI();
            inventoryUI.UpdateInventoryUI();
        }
    }
}
