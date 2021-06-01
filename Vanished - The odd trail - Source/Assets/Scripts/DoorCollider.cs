using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public delegate void LeavesWatchtowerEvent();
    public static event LeavesWatchtowerEvent OnLeaveWatchtower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLeaveWatchtower();
        }
    }


}
