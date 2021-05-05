using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOwl : EnemyBase
{
    /*public float OwlAttracRadius = 100;
    public float deerSpawnMaxTimer = 5;
    public float deerSpawnTimer;*/
    
    private float gizmosRadius = 0;
    // Start is called before the first frame update
    void Start()
    {
        deerSpawnTimer = deerSpawnMaxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool RandomPointInDonut(Vector3 center, float minRange, float maxRange, out Vector3 result)
    {
        bool hitGround = false;
        center.y -= GroundDistance();
        do
        {
            Vector3 randomPoint = center + GetRandomInDonut(minRange, maxRange);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                //Debug.Log("Spawn point: " + hit.position);
                hitGround = true;
                return true;
            }
        } while (hitGround == false);

        result = Vector3.zero;
        return false;
    }

    public static Vector3 GetRandomInDonut(float min, float max)
    {
        float rot = Random.Range(1f, 360f);
        Vector3 direction = Quaternion.AngleAxis(rot, Vector3.up) * Vector3.forward;
        Ray ray = new Ray(Vector3.zero, direction);

        return ray.GetPoint(Random.Range(min, max));
    }

    public float GroundDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            return hit.distance;
        }
        return 0;
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
    }

    public void spawnDeers(GameObject deerPrefab, float minRange, float maxRange)
    {
        deerSpawnTimer -= Time.deltaTime;
        targetSpotted = true;
        if (deerSpawnTimer < 0)
        {
            Debug.Log("Spawn!");
            Vector3 point;
            if (RandomPointInDonut(transform.position, minRange, maxRange, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
                Instantiate(deerPrefab, point, Quaternion.identity);
            }

            AlertDeers();
            deerSpawnTimer = deerSpawnMaxTimer;
        }
    }

    private void AlertDeers()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, OwlAttracRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && hitCollider.GetComponent<FiniteStateMachine>().enemyId == 2)
            {
                hitCollider.GetComponent<EnemyBase>().targetSpotted = true;
                targetPingLocation.value = target.position;
            }
        }
    }


}
