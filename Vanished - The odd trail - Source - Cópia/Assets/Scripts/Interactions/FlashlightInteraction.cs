using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightInteraction : MonoBehaviour, IInteractable
{
    private bool isActive = false;
    public bool pickedUp = false;
    private HUD hud;
    public GameObject flashlightInstructions;
    private float openTime = 3f;

    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    public void Start()
    {
        pickedUp = false;
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();

    }

    public void PickUpFlashLightItem()
    {
        pickedUp = true;
        hud.GetComponent<HUD>().CloseMessagePanel();
        Destroy(gameObject);
    }

    public void OnStartInteraction()
    {
        isActive = true;
        hud.OpenMessagePanel("Press F to pickup flashlight");
    }

    public void OnInteraction()
    {
        if (isActive)
        {
            PickUpFlashLightItem();
        }
        if (pickedUp)
        {
            flashlightInstructions.SetActive(true);
            Destroy(flashlightInstructions, openTime);
        }
    }

    public void OnEndInteraction()
    {
        isActive = false;
        hud.CloseMessagePanel();
    }
}
