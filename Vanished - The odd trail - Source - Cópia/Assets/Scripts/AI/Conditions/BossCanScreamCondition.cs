using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Boss Can Scream")]
public class BossCanScreamCondition : Condition
{
    [SerializeField]
    private bool trueIfCanScream;

    public override bool Con(FiniteStateMachine fsm)
    {
        
        if((fsm.GetEnemy() as EnemyBoss).scream)
        {
            return trueIfCanScream;
        }
        else
        {
            return !trueIfCanScream;
        }
    }
}
