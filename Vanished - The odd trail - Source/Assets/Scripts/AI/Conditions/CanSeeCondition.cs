using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Can See")]
public class CanSeeCondition : Condition
{
    [SerializeField]
    private bool trueIfCanSee;

    [SerializeField]
    private float viewDistance;

    [SerializeField]
    private bool useRayCast;

    public override bool Con(FiniteStateMachine fsm)
    {
        
        Vector3 targetDirection = fsm.GetEnemy().target.position - fsm.transform.position;
        
        //float angle = Vector3.Angle(targetDirection.normalized, fsm.transform.forward);
        float distance = targetDirection.magnitude;

        if ((distance <= viewDistance))
        {
            
            if (useRayCast)
            {
                Ray ray = new Ray(fsm.transform.position + (fsm.transform.forward / 2), targetDirection.normalized);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, viewDistance, LayerMask.GetMask("Level")))
                {
                    //Debug.Log("Test");
                    //Debug.Log(hit.transform.name);
                    if (hit.transform.tag == fsm.GetEnemy().target.tag)
                    {
                        return trueIfCanSee;
                    }
                }
            }
            else
            {
                return trueIfCanSee;
            }

        }
        return !trueIfCanSee;
    }
}
