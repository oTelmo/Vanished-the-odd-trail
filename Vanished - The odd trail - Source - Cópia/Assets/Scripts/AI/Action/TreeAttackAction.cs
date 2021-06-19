using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Tree attack")]
public class TreeAttackAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        (fsm.GetEnemy() as EnemyTree).TreeAttackStarter();
        fsm.GetEnemy().target.GetComponent<PlayerManager>().PlayerTreeAttack();

        //Rotate player to foward
        //fsm.GetEnemy().target.transform.rotation = Quaternion.RotateTowards(fsm.GetEnemy().target.transform.rotation, fsm.transform.rotation, Time.deltaTime * movementVelocity);
    }
}
