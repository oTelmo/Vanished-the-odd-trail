using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Camera cam;
    //bool isEquipped = false;

    [Header("Arrow Settings")]
    public GameObject arrowObject;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 30f;
    //public float arrowCount = 5;
    public bool onFire = false;

    private Rigidbody rb;
    private InventoryManager inventoryManager;
    private PlayerManager playerManager;

    private bool isAiming;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<InventoryManager>();
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
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

        if (arrowObject.activeSelf && Input.GetMouseButtonUp(0) && !inventoryManager.inventoryOpen)
        {
            DisableArrow();
            FireArrow();
            StartCoroutine(ReloadArrow(1.5f));
        }

        SetArrowObjFire(onFire);

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
        else
        {
            GameObject spawnArrow = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
            spawnArrow.GetComponent<Arrow>().onFire = onFire;
            Rigidbody rb = spawnArrow.GetComponent<Rigidbody>();
            rb.velocity = cam.transform.forward * shootForce;
            onFire = false;
            inventoryManager.arrowCount -= 1;
        }
    }

    public void EnableArrow()
    {
        arrowObject.SetActive(true);
    }

    public void DisableArrow()
    {
        arrowObject.SetActive(false);
    }


    public void StartFire(GameObject fire)
    {
        //SetArrowObjFire(true);
        onFire = true;
        playerManager.currentFire = fire;
    }

    IEnumerator StartArrowFire()
    {
        onFire = true;
        SetArrowObjFire(onFire);
        yield return new WaitForSeconds(10);
        onFire = false;
        SetArrowObjFire(onFire);
    }

    private void SetArrowObjFire(bool fire)
    {
        arrowObject.transform.Find("Fire").gameObject.SetActive(fire);
    }

}
