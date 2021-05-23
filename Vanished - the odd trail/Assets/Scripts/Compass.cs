using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform target;
    public Transform pointer;
    public float speed = 1.0f;

    private void Start()
    {
        
    }

    void Update()
    {
        //pointer.LookAt(target, Vector3.up);

        //Quaternion q = pointer.transform.rotation;

        //q.eulerAngles = new Vector3(0, q.eulerAngles.y, 0);

        //pointer.rotation = Quaternion.Euler(0, pointer.eulerAngles.y, 0);

        //float maxDegreesPerSecond = 60f;
        //Vector3 dir = target.position - pointer.position;
        //dir.y = pointer.position.y;
        /*Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
        pointer.rotation = Quaternion.RotateTowards(pointer.rotation, q, maxDegreesPerSecond * Time.deltaTime);*/
        //Vector3 newDir = Vector3.RotateTowards(pointer.forward, dir, speed * Time.deltaTime, 0f);

        //Debug.DrawRay(pointer.position, newDir, Color.red);

        //pointer.rotation = Quaternion.LookRotation(newDir);


        //pointer.localRotation = Quaternion.Euler(0, 360 - q.eulerAngles.y, 0);

        //pointer.LookAt(target);
        //pointer.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);

        //pointer.localRotation = Quaternion.Euler(0, 360 - pointer.root.rotation.eulerAngles.y, 0);

        Vector3 lookPos = target.position - pointer.position;
        pointer.forward = Vector3.Slerp(pointer.forward, lookPos, speed * Time.deltaTime);
    }
}
