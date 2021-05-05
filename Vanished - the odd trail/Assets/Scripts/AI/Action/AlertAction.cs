using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Alert")]
public class AlertAction : Action
{
    [SerializeField]
    private Vector3ValueSimple pingPosition;

    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetAgent().SetAgentDestination(pingPosition.value);
    }
}
