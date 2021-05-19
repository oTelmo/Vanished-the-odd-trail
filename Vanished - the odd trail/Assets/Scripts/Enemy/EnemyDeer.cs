using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeer : EnemyBase
{

    public bool deerAlerted = false;
    private StruggleCheck struggleCheck;
    private Vector3 savePlayerPos;

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

    public void DeerAttack()
    {
        //stop other enemies around
        PlacePlayerInPosition();
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

    private void PlacePlayerInPosition()
    {
        //Vector3 animPosition = transform.Find("Position1").position;
        //target.position = new Vector3(animPosition.x, target.position.y, animPosition.z);
        Vector3 position1 = transform.Find("Position1").position;
        target.position = new Vector3(position1.x, position1.y, position1.z);
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - target.position);
        float str = Mathf.Min(5 * Time.deltaTime, 1);
        target.rotation = Quaternion.Lerp(target.rotation, targetRotation, str);
    }    

    public void PlayerSucess()
    {
        target.position = target.position + new Vector3(0, 7, 0);
        target.rotation = Quaternion.Euler(0, target.rotation.y, 0);
        DeerDeath();
    }

    public void DeerDeath()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            DeerDeath();
        }
    }


}
