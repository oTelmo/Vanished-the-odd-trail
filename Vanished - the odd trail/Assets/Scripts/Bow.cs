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
    public float arrowCount = 5;

    /*[Header("Bow Equip & Unequip Settings")]
    public Transform equipBowPos;
    public Transform unequipBowPos;
    public Transform equipParent;
    public GameObject unequipParent;*/
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

        if (arrowCount < 1)
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


        /* if (Input.GetKeyDown(KeyCode.E) && !isEquipped)
         {
             EquipBow();
             isEquipped = true;

         }
         else if (Input.GetKeyDown(KeyCode.E) && isEquipped)
         {
             UnequipBow();
             isEquipped = false;
         }*/
    }

    IEnumerator ReloadArrow(float sec)
    {
        yield return new WaitForSeconds(sec);
        arrowObject.SetActive(true);
    }

    void FireArrow()
    {
        if (arrowCount < 1)
        {
            return;
        }

        GameObject spawnArrow = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        Rigidbody rb = spawnArrow.GetComponent<Rigidbody>();
        rb.velocity = cam.transform.forward * shootForce;

        arrowCount -= 1;
    }

    public void EnableArrow()
    {
        arrowObject.SetActive(true);
    }

    public void DisableArrow()
    {
        arrowObject.SetActive(false);
    }

    /*public void EquipBow()
    {
        this.transform.position = equipBowPos.position;
        this.transform.rotation = equipBowPos.rotation;
        this.transform.parent = equipParent;
    }

    public void UnequipBow()
    {
        this.transform.position = unequipBowPos.position;
        this.transform.rotation = unequipBowPos.rotation;
        this.transform.parent = unequipParent.transform;
    }*/
}
