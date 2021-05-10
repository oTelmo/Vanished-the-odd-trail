﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    private bool hasHit = false;
    private bool isActive = false;

    public GameObject hud;
    public GameObject bow;
    public Camera playerCamera;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        hud = GameObject.FindWithTag("HUD");
        bow = GameObject.FindWithTag("Bow");
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            hud.GetComponent<HUD>().CloseMessagePanel();
        }

        if (isActive)
        {
            PickUpArrow();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Arrow") && !collision.collider.CompareTag("Player"))
        {
            hasHit = true;
            Stick();
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

    private void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void PickUpArrow()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bow.GetComponent<Bow>().arrowCount++;
            hud.GetComponent<HUD>().CloseMessagePanel();
            Destroy(gameObject);
        }
    }
}
