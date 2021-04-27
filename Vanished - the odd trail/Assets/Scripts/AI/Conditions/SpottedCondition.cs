using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Spotted")]
public class SpottedCondition : Condition
{
    [SerializeField]
    private bool negation;


    public override bool Con(FiniteStateMachine fsm)
    { 
        if (fsm.GetComponentInChildren<MeshRenderer>().isVisible)
        {
            return !negation;
        }
        else
        {
            return negation;
        }
    }
}
