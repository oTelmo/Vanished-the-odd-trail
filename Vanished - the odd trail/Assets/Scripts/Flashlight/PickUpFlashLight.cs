using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashLight : MonoBehaviour
{

    private bool isActive = false;
    public bool pickedUp = false;
    public GameObject hud;

    public void Start()
    {
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            PickUpFlashLightItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = true;
            hud.GetComponent<HUD>().OpenMessagePanel("");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
        hud.GetComponent<HUD>().CloseMessagePanel();
    }

    public void PickUpFlashLightItem ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            pickedUp = true;
            hud.GetComponent<HUD>().CloseMessagePanel();
            Destroy(gameObject);
        }
    }
}
