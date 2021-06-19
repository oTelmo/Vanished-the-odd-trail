using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFileInteraction : MonoBehaviour, IInteractable
{
    public delegate void FirstDeerEvent();
    public static event FirstDeerEvent OnOpenFile;

    public HUD hud;
    public GameObject missionLog;
    private Animator anim;

    private bool firstTime = false;
    private bool isOpen = false;
    private PlayerMovement playerMovement;
    
    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        hud.OpenMessagePanel("Press F to open file");
    }

    public void OnInteraction()
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

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.CloseMessagePanel();
    }

    public void OpenFile()
    {
        anim.SetTrigger("open");
        missionLog.SetActive(true);
        playerMovement.LockPlayerMovement(true);
        hud.CloseMessagePanel();
        isOpen = true;

        if(firstTime == false)
        {
            if(OnOpenFile != null)
                OnOpenFile();

            firstTime = true;
        }
    }

    public void CloseFile()
    {
        anim.SetTrigger("close");
        playerMovement.UnLockPlayerMovement();
        missionLog.SetActive(false);
        isOpen = false;
    }
}
