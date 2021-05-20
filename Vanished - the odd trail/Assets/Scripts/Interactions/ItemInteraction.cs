using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, IInteractable
{
    public Item item;
    public int itemID;
    
    private GameObject player;
    private PlayerInventory playerInventory;
    private HUD hud;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        hud.OpenMessagePanel("Press F to pickup " + this.name);
    }

    public void OnInteraction()
    {
        playerInventory.InventoryAddItem(itemID, item);
        this.gameObject.SetActive(false);
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.CloseMessagePanel();
    }
    
}
