using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Camera cam;
    //bool isEquipped = false;

    [Header("Arrow Settings")]
    public GameObject arrowObject;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;

    private Rigidbody rb;
    private InventoryManager inventoryManager;

    private bool isAiming;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>();
        
        //UnequipBow();
    }

    // Update is called once per frame
    void Update()
    {
        isAiming = Input.GetButtonDown("Fire2");
        if (isAiming)
        {
            EnableArrow();
        }

        if (inventoryManager.arrowCount < 1)
        {
            isAiming = false;
            DisableArrow();
        }
        if (arrowObject.activeSelf && Input.GetButtonUp("Fire1") && !inventoryManager.inventoryOpen)
        {
            DisableArrow();
            FireArrow();
            StartCoroutine(ReloadArrow(1.5f));
        }
    }

    IEnumerator ReloadArrow(float sec)
    {
        yield return new WaitForSeconds(sec);
        arrowObject.SetActive(true);
    }

    void FireArrow()
    {
        if (inventoryManager.arrowCount < 1)
        {
            return;
        }

        GameObject spawnArrow = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        Rigidbody rb = spawnArrow.GetComponent<Rigidbody>();
        rb.velocity = cam.transform.forward * shootForce;

        inventoryManager.arrowCount -= 1;
    }

    public void EnableArrow()
    {
        if (inventoryManager.arrowCount >= 1)
        {
            arrowObject.SetActive(true);
        }
    }

    public void DisableArrow()
    {
        arrowObject.SetActive(false);
    }
}
