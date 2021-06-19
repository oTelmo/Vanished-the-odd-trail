using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Alerted")]
public class AlertedCondition : Condition
{

    public override bool Con(FiniteStateMachine fsm)
    {
        if ((fsm.GetEnemy() as EnemyDeer).deerAlerted)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
