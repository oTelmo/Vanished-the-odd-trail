using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeSpawn : MonoBehaviour
{
    public GameObject treePrefab;

    [Header("Stats")]
    public float minRange = 10;
    public float maxRange = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);
        }
    }

   

}
