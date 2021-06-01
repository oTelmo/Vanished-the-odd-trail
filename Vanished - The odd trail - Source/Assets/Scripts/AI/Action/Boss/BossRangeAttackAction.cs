using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Boss Range Attack")]
public class BossRangeAttackAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        
        (fsm.GetEnemy() as EnemyBoss).SpawnTrees();

    }
}
