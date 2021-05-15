using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTree : EnemyBase
{
    [Header ("Attack")]
    public float upDistance = 10;
    public float movementSpeed = 5;
    public float timeToDie = 1.5f;

    private Vector3 upPosition;

    [Header ("Camera Shake")]
    public float shakeMagX = 0.2f;
    public float shakeMagY = 0.2f;
    public float shakeDuration = 3f;

    private bool treeAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TreeAttackStarter()
    {
        //invoke TreeAttack when animation starts
        TreeAttack(movementSpeed);
    }

    private void TreeAttack(float movementSpeed)
    {
        if (!treeAttacking)
        {
            upPosition = new Vector3(target.transform.position.x, target.transform.position.y + upDistance, target.transform.position.z);
            target.GetComponent<PlayerManager>().StartCameraShake(shakeDuration, shakeMagX, shakeMagY);
            treeAttacking = true;
        }
        target.transform.position = Vector3.MoveTowards(target.transform.position, upPosition, Time.deltaTime * movementSpeed);

        if(target.transform.position == upPosition)
        {
            StartCoroutine(EndAttack(timeToDie));
        }
    }

    IEnumerator EndAttack(float timeToEnd)
    {
        yield return new WaitForSeconds(timeToEnd);
        target.GetComponent<PlayerManager>().PlayerDeath();
    }



}
