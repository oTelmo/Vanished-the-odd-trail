using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePitInteraction : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;


    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
    }
    public void OnInteraction()
    {
        
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
    }
}
