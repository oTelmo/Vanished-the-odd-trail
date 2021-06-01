using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Deer chase")]
public class DeerChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        (fsm.GetEnemy() as EnemyDeer).deerAlerted = false;
        fsm.GetAgent().SetAgentSpeed(6);
        fsm.GetAgent().GoToTarget();
    }
}
