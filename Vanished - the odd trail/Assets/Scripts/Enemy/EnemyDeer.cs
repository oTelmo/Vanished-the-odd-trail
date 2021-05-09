using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeer : EnemyBase
{

    public bool deerAlerted = false;
    private StruggleCheck struggleCheck;

    [Header("Animations")]
    private Animator animator;
    public bool attackAnimationRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        struggleCheck = FindObjectOfType<StruggleCheck>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackAnimation()
    {
        if (attackAnimationRunning == false)
        {
            struggleCheck.StartStruggleCheck(this.gameObject);
            attackAnimationRunning = true;
            animator.SetTrigger("DeerAttack");
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeerAttack"))
            { 
                //Animation is done

            }
        }
    }

    public void DeerDeath()
    {
        Destroy(this.gameObject);
    }


}
