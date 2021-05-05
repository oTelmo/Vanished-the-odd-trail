using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Alerted")]
public class AlertedCondition : Condition
{
    [SerializeField]
    private bool trueIfNotAlerted;

    public override bool Con(FiniteStateMachine fsm)
    {
        if (fsm.GetEnemy().targetSpotted)
        {
            return !trueIfNotAlerted;
        }
        else
        {
            return trueIfNotAlerted;
        }
        
    }
}
