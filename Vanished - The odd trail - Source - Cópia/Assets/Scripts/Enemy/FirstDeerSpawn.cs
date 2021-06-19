using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDeerSpawn : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
