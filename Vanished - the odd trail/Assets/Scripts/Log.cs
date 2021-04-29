using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public GameObject destroyedVersion;
        
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("arrived");
        if (other.gameObject.CompareTag("HitBox"))
        {
            
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
