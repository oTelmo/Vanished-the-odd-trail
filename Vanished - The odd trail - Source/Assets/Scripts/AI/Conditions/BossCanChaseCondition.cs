using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Boss Can See")]
public class BossCanChaseCondition : Condition
{
    [SerializeField]
    private float viewDistance;

    public override bool Con(FiniteStateMachine fsm)
    {
        Vector3 targetDirection = fsm.GetEnemy().target.position - fsm.transform.position;
        float distance = targetDirection.magnitude;

        if ((distance >= viewDistance) && (fsm.GetEnemy() as EnemyBoss).GetBossAttacking() == false)
        {
            return true;
        }
        return false;
    }
}
