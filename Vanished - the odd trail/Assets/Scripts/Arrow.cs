using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    private bool hasHit = false;
    private bool isActive = false;
    public bool onFire = false;

    public HUD hud;
    private Bow bow;
    public Camera playerCamera;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        bow = GameObject.FindWithTag("Bow").GetComponent<Bow>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            hud.CloseMessagePanel();
        }

        if (isActive)
        {
            PickUpArrow();
        }

        if (onFire)
        {
            transform.Find("Fire").gameObject.SetActive(true);
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
            hud.GetComponent<HUD>().OpenMessagePanel("Press F to pickup arrow");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
        hud.CloseMessagePanel();
    }

    private void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void PickUpArrow()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bow.arrowCount++;
            hud.CloseMessagePanel();
            Destroy(gameObject);
        }
    }
}
