using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFile : MonoBehaviour, IInteractable
{

    
    public GameObject missionLog;

    private Animator anim;
    private HUD hud;
    private bool isActive = false;
    private bool isOpen = false;
    private PlayerMovement playerMovement;

    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    private void Start()
    {
        isOpen = false;
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        hud = GameObject.FindWithTag("HUD").GetComponent<HUD>();
    }

    void Update()
    {
        anim = GetComponent<Animator>();
    }

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

    public void OnStartInteraction()
    {
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
        isActive = false;
        hud.CloseMessagePanel();
    }
}
