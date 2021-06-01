using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOwl : EnemyBase
{
    [Header("Attack stats")]
    public bool canSpawnDeers = true;
    public float owlAttracRadius = 100;
    public float deerSpawnMaxTimer = 5;

    private float deerSpawnTimer;
    private Quaternion targetRotation = Quaternion.identity;
    private Transform gfxTransform;
    private float gizmosRadius = 0;
    private Animator animator;

    private bool isDead = false;

    [Header("Sounds")]
    public AudioClip owlScream;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //deerSpawnTimer = deerSpawnMaxTimer;
        gfxTransform = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGizmosRadius(float radius)
    {
        gizmosRadius = radius;
    }

    private void OnDrawGizmosSelected()
    {
        if (gizmosRadius > 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 30);
        }
        Gizmos.DrawWireSphere(transform.position, owlAttracRadius);
    }

    public void SpawnDeers(GameObject deerPrefab, float minRange, float maxRange)
    {
        
        deerSpawnTimer -= Time.deltaTime;
        targetSpotted = true;
        if (deerSpawnTimer <= 0 && isDead == false) // use Coroutines
        {
            
            Debug.Log("Spawn!");
            Vector3 point;
            if (RandomPointInDonut(transform.position, minRange, maxRange, out point, NavMesh.AllAreas))
            {
                if (canSpawnDeers)
                {
                    Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
                    Instantiate(deerPrefab, point, Quaternion.identity);
                }
            }
            AlertDeers();
            deerSpawnTimer = deerSpawnMaxTimer;
        }
    }

    private void AlertDeers()
    {
        print("Alerting deers");
        PlayAudio(owlScream);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, owlAttracRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && hitCollider.GetComponent<EnemyDeer>() != null)
            {
                print("Alerting 1 deer");
                hitCollider.GetComponent<EnemyDeer>().deerAlerted = true;
                targetPingLocation.value = target.position;
            }
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            OwlDeath();
        }
    }

    public void OwlDeath()
    {
        isDead = true;
        animator.SetTrigger("Death");
    }

    public void DestroyOwlObject()
    {
        Destroy(this.gameObject);
    }

}
