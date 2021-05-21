using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeSpawn : MonoBehaviour
{
    public GameObject treePrefab;

    [Header("Stats")]
    public float minRange = 10;
    public float maxRange = 50;

    private EnemyManager enemyManager;
    private bool treeSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.FindWithTag("GameManager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnTree(other.transform.position);
        }
    }

    private void SpawnTree(Vector3 playerPos)
    {
        while(treeSpawned == false)
        {
            Vector3 point;
            if(RandomPointInDonut(playerPos, minRange, maxRange, out point, NavMesh.AllAreas))
            {
                Instantiate(treePrefab, point, Quaternion.identity);
            }
        }
    }

    private bool RandomPointInDonut(Vector3 center, float minRange, float maxRange, out Vector3 result, int areaMaks)
    {
        bool hitGround = false;
        center.y -= GroundDistance();
        do
        {
            Vector3 randomPoint = center + GetRandomInDonut(minRange, maxRange);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, areaMaks))
            {
                result = hit.position;
                hitGround = true;
                return true;
            }
        } while (hitGround == false);

        result = Vector3.zero;
        return false;
    }

    private static Vector3 GetRandomInDonut(float min, float max)
    {
        float rot = Random.Range(1f, 360f);
        Vector3 direction = Quaternion.AngleAxis(rot, Vector3.up) * Vector3.forward;
        Ray ray = new Ray(Vector3.zero, direction);

        return ray.GetPoint(Random.Range(min, max));
    }

    private float GroundDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            return hit.distance;
        }
        else
        {
            return 0;
        }

    }

}
