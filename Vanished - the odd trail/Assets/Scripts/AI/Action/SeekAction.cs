using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Seek")]
public class SeekAction : Action
{
    public float seekRadius = 30;
    private bool spotted = false;

    private Vector3 currentPosition;

    public override void Act(FiniteStateMachine fsm)
    {
        currentPosition = fsm.transform.position;
        fsm.GetEnemy().SetGizmosRadius(seekRadius);
        if (Vector3.Distance(fsm.GetEnemy().target.position, currentPosition) < seekRadius)
        {
            spotted = true;
        }
        else
        {
            spotted = false;
        }
        fsm.GetEnemy().targetSpotted = spotted;
    }
}
