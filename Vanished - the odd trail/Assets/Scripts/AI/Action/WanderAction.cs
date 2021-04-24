using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Wander")]
public class WanderAction : Action
{
    public float wanderRadius = 10;

    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetAgent().Wander(wanderRadius);
    }

}
