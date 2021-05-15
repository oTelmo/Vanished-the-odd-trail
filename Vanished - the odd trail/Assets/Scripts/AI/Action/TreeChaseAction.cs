using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Tree chase")]
public class TreeChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetAgent().GoToTarget();
    }
}
