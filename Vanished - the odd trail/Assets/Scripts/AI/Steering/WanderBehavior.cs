using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : Steering
{
    [SerializeField]
    private float wanderRadius = 5;

    [SerializeField]
    private float wanderOffset = 2;

    [SerializeField]
    private float wanderRate = 0.4f;

    private float wanderOrientation = 0f;

    private float GetRandomNumber()
    {
        return Random.value - Random.value;
    }

    private Vector3 AngleToVector(float angle)
    {
        return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
    }

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase)
    {
        SteeringData steeringData = new SteeringData();
        wanderOrientation += GetRandomNumber() * wanderRate;
        float agentOrientation = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
        float targetOrientation = agentOrientation + wanderOrientation;
        Vector3 targetPosition = transform.position + (wanderOffset * AngleToVector(agentOrientation));
        targetPosition += wanderRadius * AngleToVector(targetOrientation);

        steeringData.linear = Vector3.Normalize(targetPosition - transform.position);
        steeringData.linear *= steeringBase.maxAcceleration;
        steeringData.angular = 0;

        return steeringData;
    }
}
