using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBasementInteraction : MonoBehaviour, IInteractable
{
    public Transform basementSpawn;
    private GameObject hud;
    private PlayerManager playerManager;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindWithTag("HUD");
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        hud.GetComponent<HUD>().OpenMessagePanel("Press F to go outside");
    }

    public void OnInteraction()
    {
        //playerManager.TeleportPlayer(basementSpawn, );
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.GetComponent<HUD>().CloseMessagePanel();
    }
}
