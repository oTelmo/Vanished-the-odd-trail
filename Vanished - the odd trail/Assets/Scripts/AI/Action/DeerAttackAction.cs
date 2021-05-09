 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Attack")]
public class DeerAttackAction : Action
{

    public override void Act(FiniteStateMachine fsm)
    {
        (fsm.GetEnemy() as EnemyDeer).AttackAnimation();
        fsm.GetEnemy().target.GetComponent<PlayerManager>().PlayerDeerAttack();
        
    }
}
