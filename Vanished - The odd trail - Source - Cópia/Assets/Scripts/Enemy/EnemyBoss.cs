using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBoss : EnemyBase
{
    [Header("Enemy Boss")]
    public GameObject treePrefab;
    private GameObject bossZone;
    public SceneController sceneController;

    [Header("Attack Range stats")]
    public bool spawnTrees = true;
    public float minDistace = 10;
    public float maxDistance = 25;
    public float numTrees = 5;
    public GameObject bossTrees;

    [Header("Timer")]
    public float rangeAttackTimer = 10f;
    private float timeRemaining;

    
    public bool scream = false;
    private bool canRangeAttack = false;
    private bool bossAttacking = false;
    private PlayerManager playerManager;

    private Animator animator;
    private int NumFires;

    [Header("Sounds")]
    public AudioClip bossScream;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bossZone = GameObject.FindWithTag("BossZone");
        timeRemaining = rangeAttackTimer;
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        //BossGreeting();
        NumFires = 0;


    }

    // Update is called once per frame
    void Update()
    {
        /*if (bossAttacking)
        {
            BossAttack();
        }*/
    }


    public void BossGreeting()
    {
        //PlayAudio(bossScream);
        animator.SetBool("InChase", false);
        animator.SetBool("IsScream", true);

        
    }

    public void CallTrees()
    {
        foreach (Transform child in bossTrees.transform)
        {
            child.gameObject.SetActive(true);
        }
    }


    private void StartScream()
    {
        scream = true;
    }

    public void EndScream()
    {
        scream = false;
        animator.SetBool("IsScream", false);
    }


    public void BossChase()
    {
        timeRemaining -= Time.deltaTime;
        animator.SetBool("InChase", true);
        
        if (spawnTrees)
        {
            Countdown();
        }
    }

    public void BossAttack()
    {
        animator.SetBool("InChase", false);
        animator.SetTrigger("AttackState");
        bossAttacking = true;
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

    public void BossStoppedAttack()
    {
        bossAttacking = false;
    }

    public void DecreaseBossHealth(bool playAudio)
    {
        
        if (playerManager.currentFire != null)
        {
            playerManager.currentFire.GetComponent<FirePitInteraction>().fireOn = false;
            
        }
        health -= 1;
        if (playAudio)
        {
            PlayAudio(bossScream);
        }
        if(health <= 0)
        {
            BossDeath();
        }
        
    }

    private void BossDeath()
    {
        Destroy(this.gameObject);
        sceneController.WonGame();
    }

    public bool GetCanRangeAttack()
    {
        return canRangeAttack;
    }

    public bool GetBossAttacking()
    {
        return bossAttacking;
    }

    private void OnEnable()
    {
        BossInZone.OnBossEnter += StartScream;  
    }

    private void OnDisable()
    {
        BossInZone.OnBossEnter -= StartScream;
    }

    /*private void CheckFiresOn()
    {
        NumFires = 0;
        foreach (Transform child in bossZone.transform) 
        { 
            Debug.Log(child.transform.GetChild(0).name);
            if (child.transform.GetChild(0).gameObject.activeSelf)
            {
                NumFires += 1;
                Debug.Log(NumFires);
            }
        }
    }*/


}
