using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Spotted")]
public class SpottedCondition : Condition
{
    [SerializeField]
    private bool trueIfSpotted;

    public override bool Con(FiniteStateMachine fsm)
    {
        Vector3 point = Camera.main.WorldToViewportPoint(fsm.transform.position);
        //Debug.Log(point);
        /*if (point.x > -0.2f && point.x < 1.2f && point.y > -0.2f && point.y < 1.2f && point.z > 0)
        {
            Debug.Log("Visible!");
            return trueIfSpotted;
        }
        else
        {
            Debug.Log("Not visible!");
            return !trueIfSpotted;
        }*/

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(planes, fsm.GetComponent<Collider>().bounds))
        {
            //Debug.Log("Visible!");
            return trueIfSpotted;
        }
        else
        {
            //Debug.Log("Not visible!");
            return !trueIfSpotted;
        }
    }
}
