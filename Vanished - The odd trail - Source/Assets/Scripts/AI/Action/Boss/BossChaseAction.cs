using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Boss chase")]
public class BossChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetAgent().SetAgentSpeed(fsm.GetAgent().defaultChaseSpeed);
        fsm.GetAgent().GoToTarget();
        (fsm.GetEnemy() as EnemyBoss).BossChase();
    }
}
