using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAttackEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().PlayerTakeDamage(1);
        }
    }
}
