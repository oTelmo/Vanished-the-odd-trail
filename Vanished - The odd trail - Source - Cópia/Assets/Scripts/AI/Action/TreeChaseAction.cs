using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Tree chase")]
public class TreeChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        if(!(fsm.GetEnemy() as EnemyTree).GetRising())
        {
            fsm.GetAgent().GoToTarget();
            (fsm.GetEnemy() as EnemyTree).PlayMoveSound();
        }

        if (fsm.GetEnemy().DistanceToTarget() > 100)
        {
            fsm.GetAgent().SetAgentSpeed(16);
        }
        else if (fsm.GetEnemy().DistanceToTarget() > 50)
        {
            fsm.GetAgent().SetAgentSpeed(12);
        }
        else if (fsm.GetEnemy().DistanceToTarget() > 30)
        {
            fsm.GetAgent().SetAgentSpeed(8);
        }
        else
        {
            fsm.GetAgent().SetAgentSpeed(5.5f); //0.5 more than player normal speed
        }

    }
}
