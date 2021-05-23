using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IInteractable
{
    public bool collectable = false;
    public bool onFire = false;

    private Rigidbody rb;
    private HUD hud;
    private InventoryManager inventoryManager;
    private bool hasHit = false;
    private bool isActive = false;
    

    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!hasHit)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            hud.CloseMessagePanel();
        }*/

        if (onFire)
        {
            transform.Find("Fire").gameObject.SetActive(true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Arrow") && !collision.collider.CompareTag("Player") && collectable == false)
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
        inventoryManager.arrowCount++;
        hud.CloseMessagePanel();
        Destroy(gameObject);
        
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
