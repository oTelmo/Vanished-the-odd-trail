using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostcardInteraction : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;
    private bool isActive;
    private bool isOpen;

    private HUD hud;
    private PlayerMovement playerMovement;
    public GameObject postal;

    private void Start()
    {
        isActive = false;
        isOpen = false;
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        isActive = true;
        hud.OpenMessagePanel("Press F to pick up postal");
    }
    public void OnInteraction()
    {
       if (isActive)
       {
            if (isOpen)
            {
                DropPostal();
            }
            else
            {
                GrabPostal();
            }
        }
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        isActive = false;
        hud.CloseMessagePanel();
    }

    public void GrabPostal()
    {
        postal.SetActive(true);
        playerMovement.LockPlayerMovement(true);
        isOpen = true;
    }

    public void DropPostal()
    {
        postal.SetActive(false);
        playerMovement.UnLockPlayerMovement();
        isOpen = false;
    }
}
