using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
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
    public bool playerLocked = false;
    private Vector3 velocity;
    private bool isGrounded;
    private Animator anim;

    [Header("Camera Settings")]
    private MouseLook mouseLook;

    [Header("Type of Sounds")]
    public GameObject walkingSound;
    public GameObject runningSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        mouseLook = transform.GetChild(1).GetComponent<MouseLook>();
    }

    
    void Update()
    {
        if (!playerLocked)
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
                runningSound.SetActive(true);
                walkingSound.SetActive(false);
            }
            else if (Input.GetButtonUp("Sprint"))
            {
                currentSpeed = normalSpeed;
                runningSound.SetActive(false);
                walkingSound.SetActive(true);
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

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    public void LockPlayerMovement(bool lockCamera)
    {
        playerLocked = true;
        if (lockCamera) mouseLook.LockPlayerCamera(false);
    }

    public void UnLockPlayerMovement()
    {
        playerLocked = false;
        mouseLook.UnLockPlayerCamera();
    }

    /*public void CharacterAim(bool aiming)
    {
        anim.SetBool("aim", aiming);
    }

    public void CharacterPullString(bool pull)
    {
        anim.SetBool("pull", pull);
    }

    public void CharacterFireArrow()
    {
        anim.SetTrigger("fire");
    }*/

}
