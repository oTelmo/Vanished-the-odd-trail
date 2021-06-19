using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstTreesSpawn : MonoBehaviour
{
    private Vector3[] initialPositions = new Vector3[3];

    // Start is called before the first frame update
    private void Start()
    {
        foreach(Transform child in transform)
        {
            initialPositions[child.GetSiblingIndex()] = child.position;
            child.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
                
            }      
        }
    }

    public void DisableTrees()
    {
        Debug.Log("running");
        foreach (Transform child in transform)
        {
            child.position = initialPositions[child.GetSiblingIndex()];
            child.gameObject.SetActive(false);
        }
    }
}

    

   


