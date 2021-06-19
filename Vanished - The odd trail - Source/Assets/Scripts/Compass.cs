using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform northLayer;
    public Transform pointer;
    public float rotationSpeed = 1f;

    void Update()
    {
        float distanceToPlane = Vector3.Dot(pointer.up, northLayer.position - pointer.position);
        Vector3 pointOnPlane = northLayer.position - (pointer.up * distanceToPlane);
        pointer.LookAt(pointOnPlane, pointer.up);
    }
}
