using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    [SerializeField]
    private float weight = 1;

    public abstract SteeringData GetSteering(SteeringBehaviorBase steeringBase);

    public float GetWeight()
    {
        return weight;
    }

}
