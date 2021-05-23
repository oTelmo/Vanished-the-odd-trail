using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOwl : EnemyBase
{
    public bool canSpawnDeers = true;
    public float owlAttracRadius = 100;
    public float deerSpawnMaxTimer = 5;
    private float deerSpawnTimer;
    private Quaternion targetRotation = Quaternion.identity;
    private Transform gfxTransform;
    private float gizmosRadius = 0;
    // Start is called before the first frame update
    void Start()
    {
        deerSpawnTimer = deerSpawnMaxTimer;
        gfxTransform = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        //RotateOwl();
    }

    private void RotateOwl()
    {
        Vector3 targetDirection = (target.position - gfxTransform.position).normalized;
        targetRotation = Quaternion.LookRotation(targetDirection);
        gfxTransform.rotation = Quaternion.RotateTowards(gfxTransform.rotation, targetRotation, Time.deltaTime*20);
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
        if (deerSpawnTimer < 0) // use Coroutines
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

    public void OwlDeath()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            OwlDeath();
        }
    }


}
