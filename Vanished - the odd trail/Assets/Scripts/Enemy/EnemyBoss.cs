using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : EnemyBase
{
    [Header("Enemy Boss")]
    public GameObject treePrefab;
    private GameObject bossZone;

    [Header("Attack Range stats")]
    public bool spawnTrees = true;
    public float minDistace = 10;
    public float maxDistance = 25;
    public float numTrees = 5;


    private bool spawnDeers = false;
    private bool inChase = false;
    private bool canRangeAttack = false;
    private bool bossAttacking = false;

    private Animator animator;

    [Header("Timer")]
    public float rangeAttackTimer = 10f;
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bossZone = GameObject.FindWithTag("BossZone");
        timeRemaining = rangeAttackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossAttacking)
        {
            BossAttack();
        }
    }

    private void Countdown()
    {
        timeRemaining -= Time.deltaTime;
        Debug.Log(timeRemaining);
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            canRangeAttack = true;
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
        inChase = true;
        bossAttacking = false;
        timeRemaining -= Time.deltaTime;
        animator.SetTrigger("IdleState");
        if (spawnTrees)
        {
            Countdown();
        }
       
    }

    private void AttractDeers()
    {
        print("Spawn deers!");
    }

    public bool GetCanRangeAttack()
    {
        return canRangeAttack;
    }

    public void BossRangeAttack()
    {
        Debug.Log("Range attack");
        Vector3 point;
        if (RandomPointInDonut(target.position, minDistace, maxDistance, out point, NavMesh.AllAreas))
        {
            canRangeAttack = false;
        }
        
    }

    public void SpawnTrees()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0) // use Coroutines
        {
            int walkableMask = 1 << NavMesh.GetAreaFromName("Walkable");
            Debug.Log("Spawn!");
            Vector3 point;
            if (RandomPointInDonut(transform.position, bossZone.transform.localScale.x, bossZone.transform.localScale.x + maxDistance, out point, walkableMask))
            {
                Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
                GameObject tree;
                tree = Instantiate(treePrefab, point, Quaternion.identity);
            }
            timeRemaining = rangeAttackTimer;
            canRangeAttack = false;
        }
    }




}
