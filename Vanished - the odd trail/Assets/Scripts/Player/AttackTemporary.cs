using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTemporary : MonoBehaviour
{
    public GameObject line;
    public float fireRange = 10;
    public float bossRange = 100;
    public Material material;
    private GameObject currentPit;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForFirePit();
        if (Input.GetButton("Fire1"))
        {
            RaycastForBoss();
        }

    }

    private void RaycastForFirePit()
    {
        RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, fireRange))
        {
            if (hit.collider.GetComponent<FirePitInteraction>())
            {
                currentPit = hit.collider.gameObject;
                Debug.Log("pit connected");
            }
        
        }
    }

    private void RaycastForBoss()
    {
        RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, bossRange))
        {
            if (hit.collider.CompareTag("Boss"))
            {
                Debug.Log("hit boss");
                GameObject newLine = Instantiate(line, currentPit.transform);
                Line lineScript = newLine.GetComponent<Line>();
                lineScript.firepit = currentPit;
                lineScript.boss = hit.collider.gameObject;
                lineScript.material = material;
            }

        }
    }
}
