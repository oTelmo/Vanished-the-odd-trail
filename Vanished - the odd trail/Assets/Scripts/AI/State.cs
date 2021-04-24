using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class State : ScriptableObject
{
    [SerializeField]
    private Action entryAction;

    [SerializeField]
    private Action[] stateAction;

    [SerializeField]
    private Action exitAction;

    [SerializeField]
    private Transition[] transitions;

    public Action getEntryAction()
    {
        return entryAction;
    }

    public Action getExitAction()
    {
        return exitAction;
    }

    public Action[] getActions()
    {

        return stateAction;
    }

    public Transition[] getTranscisitions()
    {
        return transitions;
    }

}

