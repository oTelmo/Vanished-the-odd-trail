using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Tree attack")]
public class TreeAttackAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetEnemy().target.GetComponent<PlayerMovement>().playerCaught = true;
        fsm.GetEnemy().target.transform.rotation = Quaternion.RotateTowards(fsm.GetEnemy().target.transform.rotation, fsm.transform.rotation, Time.deltaTime * 40f);
    }
}
