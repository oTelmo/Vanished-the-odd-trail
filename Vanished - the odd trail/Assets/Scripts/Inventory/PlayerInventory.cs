using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<int> itemsID;
    public List<int> objectsID;

    [SerializeField] private GameObject inventoryTutorial;
    [SerializeField] private GameObject firefly;

    public GameObject inventoryUIPrefab;
    public GameObject canvas;
    public GameObject hud;

    private GameObject inventoryUIObj;
    private InventoryUI inventoryUI;
    private Inventory inventory;
    private PlayerMovement playerMovement;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventory = new Inventory();
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>();
        itemsID = inventoryManager.currentItemsID;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerMovement.playerLocked = true;
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
                playerMovement.playerLocked = false;
                inventoryManager.inventoryOpen = false;
                transform.GetChild(1).GetComponent<MouseLook>().UnLockPlayerCamera();
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

    public void InventoryAddItem(int itemID, Item item)
    {
        inventory.AddItem(item);
        itemsID.Add(itemID);
        if (inventoryUI)
        {
            inventoryUI.ClearInventoryUI();
            inventoryUI.UpdateInventoryUI();
        }
        if (itemsID.Count > 1)
        {
            inventoryTutorial.SetActive(false);
        }
        else
        {
            StartCoroutine(Tutorial());
        }
        if (itemID == 1)
        {
            firefly.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    public void InventoryAddObject(int objectID)
    {
        objectsID.Add(objectID);
    }

    IEnumerator Tutorial()
    {
        inventoryTutorial.SetActive(true);
        yield return new WaitForSeconds(2);
        inventoryTutorial.SetActive(false);
    }
}
