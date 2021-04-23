using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow01 : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider bx;
    bool disableRotation;

    public GameObject hud;
    bool isActive = false;
    Bow bowScript;

    // Start is called before the first frame update
    void Start()
    {
        bowScript = GetComponent<Bow>();
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();

        hud = GameObject.FindWithTag("HUD");

        //this.GetComponent<BoxCollider>().enabled = false;


    }

    private void Update()
    {
        if (isActive)
        {
            PickUpArrow();
        }

        if (!disableRotation)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("Arrow"))
        {
            disableRotation = true;
            rb.isKinematic = true;
            bx.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isActive = true;
        hud.GetComponent<HUD>().OpenMessagePanel("");

    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
        hud.GetComponent<HUD>().CloseMessagePanel();
    }

    public void PickUpArrow()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("teste2");
            bowScript.bowSettings.arrowCount++;
            Destroy(gameObject);
        }
    }
}
