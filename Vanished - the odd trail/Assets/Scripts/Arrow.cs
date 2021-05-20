using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    private bool hasHit = false;
    private bool isActive = false;
    public bool onFire = false;

    private HUD hud;
    public Camera playerCamera;
    private InventoryManager inventoryManager;

    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>();
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

    private void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void PickUpArrow()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            inventoryManager.arrowCount++;
            hud.CloseMessagePanel();
            Destroy(gameObject);
        }
    }

    public void OnStartInteraction()
    {
        isActive = true;
        hud.OpenMessagePanel("Press F to pick up arrow");
    }

    public void OnInteraction()
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
    }

    public void OnEndInteraction()
    {
        isActive = false;
        hud.CloseMessagePanel();
    }
}
