using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchet : MonoBehaviour
{
    float speed = 10f;
    public GameObject child;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            child.SetActive(true);
        } 
        else if (Input.GetMouseButtonUp(0))
        {
            child.SetActive(false);
        }
    }
}
