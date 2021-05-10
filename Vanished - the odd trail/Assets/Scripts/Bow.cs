using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Camera cam;
    //bool isEquipped = false;

    [Header("Arrow Settings")]
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
       
        if (Input.GetMouseButtonDown(0) && !inventoryManager.inventoryOpen)
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
