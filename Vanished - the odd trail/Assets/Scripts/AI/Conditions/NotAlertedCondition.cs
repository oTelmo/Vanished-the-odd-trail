using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/At Destination")]
public class NotAlertedCondition : Condition
{
    [SerializeField]
    private Vector3ValueSimple pingPosition;

    [SerializeField]
    private float distanceCheck;

    public override bool Con(FiniteStateMachine fsm)
    {
        if (fsm.GetAgent().IsCloseToPosition(pingPosition.value, distanceCheck) || (fsm.GetEnemy() as EnemyDeer).deerAlerted == false)
        {
            Debug.Log("Deer arrived");
            (fsm.GetEnemy() as EnemyDeer).deerAlerted = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
