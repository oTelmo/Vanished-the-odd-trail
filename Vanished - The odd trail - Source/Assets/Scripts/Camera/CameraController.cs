using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    //This handles Camera Settings
    [System.Serializable]
    public class CameraSettings
    {
        [Header("Camera Move Settings")]
        public float zoomSpeed = 5;
        public float moveSpeed = 5;
        public float rotationSpeed = 5;
        public float originalFieldOfView = 70;
        public float zoomFieldOfView = 20;
        public float mouseXSensitivity = 5;
        public float mouseYSensitivity = 5;
        public float maxClampAngle = 90;
        public float minClampAngle = -30;
    }
    [SerializeField]
    public CameraSettings cameraSettings;

    [System.Serializable]
    public class CameraInputSettings
    {
        public string mouseXAxis = "Mouse X";
        public string mouseYAxis = "Mouse Y";
        public string aimingInput = "Fire2";
    }
    [SerializeField]
    public CameraInputSettings inputSettings;

    Transform center;
    Transform target;

    Camera mainCam;

    float cameraXrotation = 0;
    float cameraYrotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        center = transform.GetChild(0);
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
            return;
    
        if (!Application.isPlaying)
            return;

        RotateCamera();
        ZoomCamera();
    }

    void LateUpdate()
    {
        if(target)
        {
            FollowPlayer();
        }
        else
        {
            FindPlayer();
        }
    }

    void FindPlayer()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FollowPlayer()
    {
        Vector3 moveVector = Vector3.Lerp(transform.position, target.transform.position, cameraSettings.moveSpeed * Time.deltaTime);

        transform.position = moveVector;
    }

    void RotateCamera()
    {
        cameraXrotation += Input.GetAxis(inputSettings.mouseYAxis) * cameraSettings.mouseYSensitivity;
        cameraYrotation += Input.GetAxis(inputSettings.mouseXAxis) * cameraSettings.mouseXSensitivity;

        cameraXrotation = Mathf.Clamp(cameraXrotation, cameraSettings.minClampAngle, cameraSettings.maxClampAngle);

        cameraYrotation = Mathf.Repeat(cameraYrotation, 360);

        Vector3 rotatingAngle = new Vector3(cameraXrotation, cameraYrotation, 0);

        Quaternion rotation = Quaternion.Slerp(center.transform.localRotation, Quaternion.Euler(rotatingAngle), cameraSettings.rotationSpeed * Time.deltaTime);

        center.transform.localRotation = rotation;
    }

    void ZoomCamera()
    {
        if (Input.GetButton(inputSettings.aimingInput))
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, cameraSettings.zoomFieldOfView, cameraSettings.zoomSpeed * Time.deltaTime);
        }
        else
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, cameraSettings.originalFieldOfView, cameraSettings.zoomSpeed * Time.deltaTime);
        }
    }
}
