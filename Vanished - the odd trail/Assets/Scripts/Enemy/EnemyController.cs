using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    public int enemyHealth = 2;

    [HideInInspector]
    public bool targetSpotted = false;

    private float gizmosRadius = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGizmosRadius(float radius)
    {
        gizmosRadius = radius;
    }

    void OnDrawGizmosSelected()
    {
        if(gizmosRadius > 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 30);
        }
        
    }
}
