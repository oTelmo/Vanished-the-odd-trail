using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : EnemyBase
{

    private bool bossAttacking = false;

    private Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossAttacking)
        {
            BossAttack();
        }
    }

    public void BossAttackStarter()
    {
        //Invoke BossActtack for animation
        bossAttacking = true;
    }

    private void BossAttack()
    {
        animator.SetTrigger("AttackState");
    }

    public void BossChase()
    {
        animator.SetTrigger("IdleState");
    }

}
