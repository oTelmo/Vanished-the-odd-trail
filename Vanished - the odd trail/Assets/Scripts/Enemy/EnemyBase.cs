using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    [HideInInspector]
    public Transform target;

    [Header ("Enemy Base")]
    public int health = 2;
    private AudioSource audioSource;

    [HideInInspector]
    public bool targetSpotted = false;
    [HideInInspector]
    public Vector3 targetLocation;

    public Vector3ValueSimple targetPingLocation;

    void Awake()
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

    public bool RandomPointInDonut(Vector3 center, float minRange, float maxRange, out Vector3 result, int areaMaks)
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
        else
        {
            return 0;
        }
        
    }

}
