using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public int enemyId;
    public State initialState;
    public State currentState;
    private EnemyBase enemyBase;
    private MyNavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        enemyBase = GetComponent<EnemyBase>();
        /*switch (enemyId)
        {
            case 1:
                enemyBase = GetComponent<EnemyOwl>();
                Debug.Log(enemyId + " Owl");
                break;
            case 2:
                enemyBase = GetComponent<EnemyDeer>();
                Debug.Log(enemyId + " Deer");
                break;
            case 3:
                enemyBase = GetComponent<EnemyTree>();
                Debug.Log(enemyId + " Tree");
                break;
            case 4:
                enemyBase = GetComponent<EnemyBoss>();
                Debug.Log(enemyId + " Boss");
                break;
        }*/


        currentState = initialState;
        navMeshAgent = GetComponent<MyNavMeshAgent>();
    }

    public MyNavMeshAgent GetAgent()
    {
        return navMeshAgent;
    }

    public EnemyBase GetEnemy()
    {
        return enemyBase;
    }

    // Update is called once per frame
    void Update()
    {
         Transition triggeredTransition = null;
         foreach (Transition t in currentState.getTranscisitions())
         {
             if (t.IsTriggered(this))
             {
                 triggeredTransition = t;
                 break;
             }
         }

         List<Action> actions = new List<Action>();
         if (triggeredTransition)
         {
             State targetState = triggeredTransition.GetTargetState();
             actions.Add(currentState.getExitAction());
             actions.Add(triggeredTransition.GetAction());
             actions.Add(targetState.getEntryAction());
             currentState = targetState;
             Debug.Log(currentState);
         }
         else
         {
             foreach (Action a in currentState.getActions())
             {
                 actions.Add(a);
             }
         }
         DoActions(actions);
    }

     void DoActions(List<Action> actions)
     {
         foreach (Action a in actions)
         {
             if (a != null)
             {
                 a.Act(this);
             }
         }
     }
}
