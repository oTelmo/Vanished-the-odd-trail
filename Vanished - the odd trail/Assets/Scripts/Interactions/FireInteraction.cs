using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : MonoBehaviour, IInteractable
{

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    private void Start()
    {

    }

    public void OnStartInteraction()
    {
        if (GameObject.FindWithTag("Bow") != null)
        {
            GameObject.FindWithTag("Bow").GetComponent<Bow>().StartFire(transform.parent.gameObject);
        }
    }

    public void OnInteraction()
    {

    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
    }
}
