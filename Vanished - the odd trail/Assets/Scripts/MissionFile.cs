using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFile : MonoBehaviour
{

    public GameObject hud;
    public GameObject missionLog;
    private Animator anim;

    private bool isActive = false;
    private bool isOpen = false;
    private PlayerMovement playerMovement;

    private void Start()
    {
        isOpen = false;
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }



    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        if (isActive && Input.GetKeyDown(KeyCode.F))
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

    private void OnTriggerEnter(Collider other)
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
    }

    public void OpenFile()
    {
        anim.SetTrigger("open");
        missionLog.SetActive(true);
        playerMovement.LockPlayerMovement(true);
        hud.GetComponent<HUD>().CloseMessagePanel();
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
