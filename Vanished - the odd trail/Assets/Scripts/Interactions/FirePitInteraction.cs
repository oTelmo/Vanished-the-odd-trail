using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePitInteraction : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;
    private GameObject player;
    public GameObject boss;
    private PlayerManager playerManager;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
    }
    public void OnInteraction()
    {
        Debug.Log("OnInteraction");
        if (playerManager.hasBossItems)
        {
            Debug.Log("Spawn boss");
            boss.SetActive(true);
        }
        else
        {
            //erro message
        }

        
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
    }
}
