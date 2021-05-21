using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFile : MonoBehaviour, IInteractable
{

    public HUD hud;
    public GameObject missionLog;
    private Animator anim;

    private bool isActive = false;
    private bool isOpen = false;
    private PlayerMovement playerMovement;
    
    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    private void Start()
    {
        isOpen = false;
        anim = GetComponent<Animator>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }



    // Update is called once per frame
    void Update()
    {
       
        /*if (isActive && Input.GetKeyDown(KeyCode.F))
        {
            if (isOpen)
            {
                CloseFile();
            }
            else
            {
                OpenFile();
            }
        }*/
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        isActive = true;
        hud.OpenMessagePanel("Press F to open file");
    }

    public void OnInteraction()
    {
        if (isActive)
        {
            if (isOpen)
            {
                CloseFile();
            }
            else
            {
                OpenFile();
            }
        }
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        isActive = false;
        hud.CloseMessagePanel();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = true;
            hud.GetComponent<HUD>().OpenMessagePanel("Press F to open file");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
        hud.GetComponent<HUD>().CloseMessagePanel();
    }*/

    public void OpenFile()
    {
        anim.SetTrigger("open");
        missionLog.SetActive(true);
        playerMovement.LockPlayerMovement(true);
        hud.CloseMessagePanel();
        isOpen = true;
    }

    public void CloseFile()
    {
        anim.SetTrigger("close");
        playerMovement.UnLockPlayerMovement();
        missionLog.SetActive(false);
        isOpen = false;
    }
}
