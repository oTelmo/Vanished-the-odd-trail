﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hatchet : MonoBehaviour
{
    public GameObject child;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            child.SetActive(true);
            anim.SetBool("attack", true);
        } 
        else if (Input.GetMouseButtonUp(0))
        {
            child.SetActive(false);
            anim.SetBool("attack", false);
        }
    }
}
