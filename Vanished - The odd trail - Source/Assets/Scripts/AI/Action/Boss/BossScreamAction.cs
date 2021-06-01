using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Boss Scream")]
public class BossScreamAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        (fsm.GetEnemy() as EnemyBoss).BossGreeting();
    }
}
