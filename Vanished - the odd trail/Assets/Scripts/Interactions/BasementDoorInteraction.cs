using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoorInteraction : MonoBehaviour, IInteractable
{
    public Transform basementSpawn;
    private GameObject player;
    private PlayerManager playerManager;
    private GameObject hud;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
        hud = GameObject.FindWithTag("HUD");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        hud.GetComponent<HUD>().OpenMessagePanel("Press F to go inside.");
    }

    public void OnInteraction()
    {
        Debug.Log("Teleport");
        playerManager.TeleportPlayer(basementSpawn.position, Quaternion.Euler(0, 0, 0));
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.GetComponent<HUD>().CloseMessagePanel();
    }

    // Start is called before the first frame update
    
}
