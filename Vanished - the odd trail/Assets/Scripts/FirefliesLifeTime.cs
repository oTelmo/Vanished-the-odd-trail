using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesLifeTime : MonoBehaviour
{

    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        
    }

    public void StopFireflies()
    {
        ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
