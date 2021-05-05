using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Attract")]
public class AttractAction : Action
{
    [SerializeField]
    private GameObject deerPrefab;
    [SerializeField]
    private float maxRange = 50f;
    [SerializeField]
    private float minRange = 30f;


    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetEnemy().PlayAudio();
        fsm.GetEnemy().spawnDeers(deerPrefab, minRange, maxRange);
    }

}