﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float currentSpeed = 4f;
    public float sprintSpeed = 8f;
    public float normalSpeed = 4f;
    public float crouchSpeed = 1f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool playerCaught = false;
    private Vector3 velocity;
    private bool isGrounded;


    private void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (!playerCaught)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            controller.Move(move * currentSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (Input.GetButtonDown("Sprint"))
            {
                currentSpeed = sprintSpeed;
            }
            else if (Input.GetButtonUp("Sprint"))
            {
                currentSpeed = normalSpeed;
            }

            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                controller.height = 1.0f;
                currentSpeed = crouchSpeed;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                controller.height = 2.35f;
                currentSpeed = normalSpeed;
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        /*else
        {
            transform.GetChild(1).GetComponent<MouseLook>().LockPlayerCamera(true);
        }*/
    }
}