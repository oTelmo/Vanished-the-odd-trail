using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgentMovement : MonoBehaviour
{

    public float wanderRadius = 10;
    public float wanderTimer = 5;
    private NavMeshAgent agent;
    private MyNavMeshAgent myNavMeshAgent;
    
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = wanderTimer;
        //agent = GetComponent<NavMeshAgent>();
        myNavMeshAgent = GetComponent<MyNavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void Wander()
    {
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            myNavMeshAgent.agent.updateRotation = false;
           myNavMeshAgent.agent.SetDestination(newPos);

            timer = 0;
        }

        /*if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);

            myNavMeshAgent.agent.Move(newPos * Time.deltaTime);
            timer = 0;
        }*/


}

public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
{
Vector3 randDirection = Random.insideUnitSphere * dist;

randDirection += origin;

NavMeshHit navHit;

NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

return navHit.position;
}
}
