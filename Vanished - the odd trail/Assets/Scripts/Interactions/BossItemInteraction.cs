using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemInteraction : MonoBehaviour, IInteractable
{
    public int objectID;
    private GameObject hud;
    private PlayerInventory playerInventory;
    private WordManager wordManager;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindWithTag("HUD");
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        wordManager = GameObject.FindWithTag("GameManager").GetComponent<WordManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        hud.GetComponent<HUD>().OpenMessagePanel("Press F to pick up");
    }

    public void OnInteraction()
    {
        playerInventory.InventoryAddObject(objectID);
        wordManager.StartEndGame();
        gameObject.SetActive(false);
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.GetComponent<HUD>().CloseMessagePanel();
    }
}
