using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    //public State initialState;
    //private State currentState;
    private MyNavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        //currentState = initialState;
        navMeshAgent = GetComponent<MyNavMeshAgent>();
    }

    public MyNavMeshAgent GetAgent()
    {
        return navMeshAgent;
    }

    // Update is called once per frame
    /* void Update()
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
     }*/
}
