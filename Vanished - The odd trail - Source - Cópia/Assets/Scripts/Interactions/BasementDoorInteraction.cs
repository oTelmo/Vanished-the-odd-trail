using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoorInteraction : MonoBehaviour, IInteractable
{
    public Transform whereToSpawn;
    public string whereToGo;
    private GameObject player;
    private PlayerManager playerManager;
    private GameObject hud;

    public GameObject ambientSound;
    private AudioSource ambientAudioSource;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
        hud = GameObject.FindWithTag("HUD");
        ambientAudioSource = ambientSound.GetComponent<AudioSource>();
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        hud.GetComponent<HUD>().OpenMessagePanel("Press F to go " + whereToGo);
    }

    public void OnInteraction()
    {
        Debug.Log("Teleport");
        playerManager.TeleportPlayer(whereToSpawn.position, Quaternion.Euler(0, 0, 0));
        
        if(whereToGo == "inside")
        {
            ambientAudioSource.Stop();
        }
        else if (whereToGo == "outside")
        {
            ambientAudioSource.Play();
        }

    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.GetComponent<HUD>().CloseMessagePanel();
    }

    // Start is called before the first frame update
    
}
