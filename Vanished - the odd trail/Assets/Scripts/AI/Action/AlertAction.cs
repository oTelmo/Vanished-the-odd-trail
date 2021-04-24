using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Alert")]
public class AlertAction : Action
{
    [SerializeField]
    private GameObject deerPrefab;
    [SerializeField]
    private float spawnTimer = 5f;
    [SerializeField]
    private float maxRange = 50f;
    [SerializeField]
    private float minRange = 30f;

    private float timer = 0;

    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetEnemy().PlayAudio();
        spawnTimer -= Time.deltaTime;
        Debug.Log(timer);
        if(spawnTimer<0)
        {
            Debug.Log("Spawn!");
            Vector3 point;
            if (fsm.GetEnemy().RandomPoint(fsm.transform.position, minRange, maxRange, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
                Instantiate(deerPrefab, point, Quaternion.identity);
            }
            spawnTimer = 5;
        }
        





    }

}