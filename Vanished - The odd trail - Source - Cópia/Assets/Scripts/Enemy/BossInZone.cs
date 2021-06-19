using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInZone : MonoBehaviour
{
    public delegate void BossInZoneEvent();
    public static event BossInZoneEvent OnBossEnter;

    private bool bossEnter = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss") && bossEnter == false)
        {
            OnBossEnter();
            bossEnter = true;
        }
    }
}
