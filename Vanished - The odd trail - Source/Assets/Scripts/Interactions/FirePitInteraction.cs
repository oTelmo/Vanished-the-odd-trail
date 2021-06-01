using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePitInteraction : MonoBehaviour, IInteractable
{
    
    private GameObject player;
    public WordManager wordManager;
    public HUD hud;
    private PlayerInventory playerInventory;
    public bool fireOn = false;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (fireOn)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        if (fireOn == false)
        {
            if (playerInventory.objectsID.Count > 0)
            {
                hud.OpenMessagePanel("Press F to deposite item");
            }
            else
            {
                hud.OpenMessagePanel("No item found");
            }
        }
    }

    public void OnInteraction()
    {
        if(fireOn == false && playerInventory.objectsID.Count > 0)
        {
            Debug.Log("OnInteraction");
            wordManager.StartBossFight();
        } 
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.CloseMessagePanel();
    }
}
