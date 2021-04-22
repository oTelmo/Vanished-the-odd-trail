using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgent : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;

    public Transform target;
    //public float wanderRadius = 10;
    //public float wanderTimer = 5;
    private Transform finalPoint;
    
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //GoToNextWaypoint();
        //timer = wanderTimer;
    }

    /*public void GoToNextWaypoint()
    {
        currentWaypoint = Random.Range(0, waypoints.Length);
        agent.SetDestination(waypoints[currentWaypoint].position);
    }*/

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
        agent.SetDestination(target.position);
    }

    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void MoveAgent(Vector3 offSet)
    {
        agent.Move(offSet);
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        /*if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }*/

        //Wander();
    }

    /*public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }*/

    /*public void Wander()
    {
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }*/
}
