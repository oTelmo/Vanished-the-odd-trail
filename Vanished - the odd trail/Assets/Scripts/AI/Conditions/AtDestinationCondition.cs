using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/At Destination")]
public class AtDestinationCondition : Condition
{
    [SerializeField]
    private Vector3ValueSimple pingPosition;

    public override bool Con(FiniteStateMachine fsm)
    {
        if (fsm.GetAgent().IsCloseToPosition(pingPosition.value, 5))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
