using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    private AudioSource audioSource;
    public int enemyHealth = 2;

    [HideInInspector]
    public bool targetSpotted = false;

    private bool treeAttacked = false;
    private float gizmosRadius = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
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

    public void TreeAttackPlayer(float movementSpeed)
    {
        Vector3 upPosition = new Vector3(target.transform.position.x, transform.GetChild(0).position.y, target.transform.position.z);
        target.transform.position = Vector3.MoveTowards(target.transform.position, upPosition, Time.deltaTime * movementSpeed);


        if (!treeAttacked)
        {
            target.GetComponent<PlayerManager>().StartCameraShake( 3f, 0.2f, 0.2f);
            treeAttacked = true;
        }
        
    }

}
