using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Boss Can Range Attack")]
public class BossCanRangeAttackCondition : Condition
{
    [SerializeField]
    private bool trueIfCanAttack;

    public override bool Con(FiniteStateMachine fsm)
    {
        if ((fsm.GetEnemy() as EnemyBoss).GetCanRangeAttack())
        {
            return trueIfCanAttack; // if trueIfCanAttack true is the same as having just a return true
        }
        else
        {
            return !trueIfCanAttack; //if trueIfCanAttack is false it returns true here for the BossCannotRangeAttackCondition condition
        }

    }
}
