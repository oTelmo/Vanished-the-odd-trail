﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        /*if (moveX == 0)
        {
            anim.SetFloat("forward", 0.0f);
        }

        if (moveZ == 0)
        {
            anim.SetFloat("strafe", 0.0f);
        }

        if (moveX > 0)
        {
            anim.SetFloat("forward", 1);
        }
        else if (moveX < 0)
        {
            anim.SetFloat("forward", -1);
        }
        else if (moveZ > 0)
        {
            anim.SetFloat("strafe", 1);
        }
        else if (moveZ < 0)
        {
            anim.SetFloat("strafe", -1);
        }

        if (Input.GetButton("Sprint"))
        {
            anim.SetBool("sprint", true);
        }*/

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
