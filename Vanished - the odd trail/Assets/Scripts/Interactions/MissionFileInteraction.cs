using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFileInteraction : MonoBehaviour, IInteractable
{
<<<<<<< Updated upstream:Vanished - the odd trail/Assets/Scripts/MissionFile.cs
    public WordManager wordManager;
=======
    public delegate void FirstDeerEvent();
    public static event FirstDeerEvent OnOpenFile;

>>>>>>> Stashed changes:Vanished - the odd trail/Assets/Scripts/Interactions/MissionFileInteraction.cs
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
<<<<<<< Updated upstream:Vanished - the odd trail/Assets/Scripts/MissionFile.cs
        wordManager.SpawnFirstDeer();
        if (isActive)
=======
        if (isOpen)
>>>>>>> Stashed changes:Vanished - the odd trail/Assets/Scripts/Interactions/MissionFileInteraction.cs
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
