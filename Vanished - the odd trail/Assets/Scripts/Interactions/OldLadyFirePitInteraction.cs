using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLadyFirePitInteraction : MonoBehaviour, IInteractable
{
    private bool fireOn = false;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    private void Start()
    {

    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        if (fireOn)
        {
            if(GameObject.FindWithTag("Bow") != null)
            {
                GameObject.FindWithTag("Bow").GetComponent<Bow>().StartFire();
            }
        }
    }
    public void OnInteraction()
    {
        
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
    }

    public void StartOldLadyFirePit()
    {
        fireOn = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

}
