using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    private EnemyController enemyController;

    [HideInInspector]
    public bool targetSpotted = false;

    //public float wanderRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<EnemyController>();
    }

    public bool IsAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if ((!agent.hasPath) || (agent.velocity.sqrMagnitude == 0))
                {
                    return true;
                }
            }
        }
       
        return false;
    }

    public void GoToTarget()
    {
        agent.SetDestination(enemyController.target.position);
    }

    public void StopAgent(bool immediateStop)
    {
        agent.isStopped = true;
        if (immediateStop)
        {
            agent.velocity = Vector3.zero;
        }
        agent.ResetPath();
    }

    public void SetAgentSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void Wander(float wanderRadius)
    {
        if (IsAtDestination())
        {

            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
        }

        NavMeshHit hit;
        if (NavMesh.FindClosestEdge(transform.position, out hit, NavMesh.AllAreas))
        {
            //DrawCircle(transform.position, hit.distance, Color.red);
            Debug.DrawRay(hit.position, Vector3.up, Color.red);
            if (Vector3.Distance(hit.position, transform.position) < 2)
            {

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawCircle(Vector3 center, float radius, Color color)
    {
        Vector3 prevPos = center + new Vector3(radius, 0, 0);
        for (int i = 0; i < 30; i++)
        {
            float angle = (float)(i + 1) / 30.0f * Mathf.PI * 2.0f;
            Vector3 newPos = center + new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            Debug.DrawLine(prevPos, newPos, color);
            prevPos = newPos;
        }
    }

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
