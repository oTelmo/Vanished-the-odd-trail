using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    public float maxAcceleration = 4;
    public float maxAngularAcceleration = 3;
    public float drag = 1;
    private Steering[] steerings;
    private Rigidbody rb;
    private MyNavMeshAgent navMeshAgent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        steerings = GetComponents<Steering>();
        navMeshAgent = GetComponent<MyNavMeshAgent>();
        //rigidbody.drag = drag;
    }

    private void FixedUpdate()
    {
        Vector3 acceleration = Vector3.zero;
        float angular = 0;
        foreach (Steering steering in steerings)
        {
            SteeringData steeringData = steering.GetSteering(this);
            acceleration += steeringData.linear;
            angular += steeringData.angular;
        }

        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration = acceleration.normalized * maxAcceleration;
        }

        /*rigidbody.AddForce(acceleration);
        if (angular != 0)
        {
            rigidbody.rotation = Quaternion.Euler(0, angular, 0);
        }*/

        //navMeshAgent.MoveAgent(acceleration);

    }
}
