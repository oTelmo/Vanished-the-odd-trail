using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Seek")]
public class SeekAction : Action
{
    [SerializeField]
    private float seekRadius = 30;
    

    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetEnemy().StopAudio();
        fsm.GetEnemy().targetSpotted = false;
        //fsm.GetEnemy().SetGizmosRadius(seekRadius);
    }
}
