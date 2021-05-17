using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform playerBody;
    public bool lockMouse = false;

    float xRotation = 0f;

    [Header("Camera Settings")]
    public float mouseSensitivity = 30f;
    public float zoomSpeed = 5;
    public float originalFieldOfView = 80.6f;
    public float zoomFieldOfView = 35;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (!lockMouse)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //over rotate and look behind the player

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }

        ZoomCamera();

    }

    public void LockPlayerCamera(bool resetCamera)
    {
        lockMouse = true;
        if (resetCamera)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.deltaTime * 40f);
        }
    }

    public void UnLockPlayerCamera()
    {
        lockMouse = false;
    }

    private void ZoomCamera()
    {
        if (Input.GetButton("Fire2"))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, zoomFieldOfView, zoomSpeed * Time.deltaTime);
        }
        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, originalFieldOfView, zoomSpeed * Time.deltaTime);
        }
    }
}
