using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hatchet : MonoBehaviour
{
    public GameObject hitBox;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //
            animator.SetBool("attack", true);
        } 
        else if (Input.GetMouseButtonUp(0))
        {
            //
            animator.SetBool("attack", false);
        }
    }

    public void ActivateHitBox()
    {
        hitBox.SetActive(true);
    }

    public void DisableHitBox()
    {
        hitBox.SetActive(false);
    }
}
