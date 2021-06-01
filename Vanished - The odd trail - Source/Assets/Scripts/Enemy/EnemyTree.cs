using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTree : EnemyBase
{
    [Header ("Attack stats")]
    public float upDistance = 10;
    public float movementSpeed = 5;
    public float timeToDie = 1.5f;

    [Header ("Camera Shake")]
    public float shakeMagX = 0.2f;
    public float shakeMagY = 0.2f;
    public float shakeDuration = 3f;

    private Vector3 upPosition;
    private bool treeAttacking = false;
    private bool rising = true;
    private Animator animator;

    [Header("Sounds")]
    public AudioClip treeMovement;

    private bool canDie = false;
    private float threshold = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canDie)
        {
            TreeDeath();
        }
    }

    public void PlayMoveSound()
    {
        if(!audioSource.isPlaying)
            PlayAudio(treeMovement);
    }

    public void TreeAttackStarter()
    {
        //invoke TreeAttack to wait for animation start
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

    public void IdleState()
    {
        rising = false;
        animator.SetTrigger("Idle");
    }

    public bool GetRising()
    {
        return rising;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            if(other.GetComponent<Arrow>().onFire)
                canDie = true;
                //TreeDeath();
        }
    }

    public void TreeDeath()
    {
        threshold += Time.deltaTime;
        renderer.material.SetFloat("_DissolveThreshold", threshold);
        Debug.Log(renderer.material.GetFloat("_DissolveThreshold"));
        if (renderer.material.GetFloat("_DissolveThreshold") >= 1)
            Destroy(this.gameObject);
    }



}
