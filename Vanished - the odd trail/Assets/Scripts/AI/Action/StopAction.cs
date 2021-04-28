using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Stop")]
public class StopAction : Action
{
    [SerializeField]
    

    public override void Act(FiniteStateMachine fsm)
    {
        if (fsm.GetAgent() != null)
        {
            
            fsm.GetAgent().StopAgent(true);
        }
    }
}
