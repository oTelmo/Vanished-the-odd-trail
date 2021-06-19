using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player stats")]
    private int health;
    public int maxHealth = 2;
    private int halfHealth;
   
    [Header("Player camera")]
    public GameObject mainCamera;
    public GameObject animationCamera;
    private CameraShake cameraShake;
    public GameObject lowHeathScreen;

    private SceneController sceneController;
    private PlayerMovement playerMovement;
    private GameObject gameManager;
    private CharacterController characterController;
    private Animator crossFadeAnimator;
    public bool isInventoryOpen = false;

    [Header("Fire")]
    public GameObject currentFire;

    private Animator animator;
    [Header("Animations")]
    public bool playWakingAnimation = true;
    public bool deerAttackRunning = false;

    [Header("Teleport Locations")]
    public Transform bossZone;
    public Transform watchtower;
    public Transform oldLadyHouse;
    public Transform campSite;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        health = maxHealth;
        halfHealth = (health / maxHealth);
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        gameManager = GameObject.FindWithTag("GameManager");
        sceneController = gameManager.GetComponent<SceneController>();
        crossFadeAnimator = gameManager.transform.GetChild(0).gameObject.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        cameraShake = mainCamera.GetComponent<CameraShake>();
        PlayerWakingUp();
    }

    // Update is called once per frame
    void Update()
    {
        TeleportCheats();
    }

    private void PlayerWakingUp()
    {
        if (playWakingAnimation)
        {
            playerMovement.LockPlayerMovement(true);
            animator.SetTrigger("WakingUp");
        }
    }

    private void OnWakeAnimationEnd()
    {
        //animator.SetTrigger("WakingUp");
        playerMovement.UnLockPlayerMovement();
        mainCamera.transform.rotation = animationCamera.transform.rotation;
    }

   
    public void PlayerDeerAttack()
    {
        if (deerAttackRunning == false)
        {
            deerAttackRunning = true;
            //playerMovement.playerLocked = true;
            playerMovement.LockPlayerMovement(true);
            animator.SetTrigger("deerAttack");
            //animator.SetBool("DeerAttack", true);
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeerAttack"))
            {
                animator.SetBool("InStruggle", true);
            }
        }
    }

    public void PlayerDeerStopAttack()
    {
        deerAttackRunning = false;
        //playerMovement.playerLocked = false;
        //mouseLook.UnLockPlayerCamera();
        playerMovement.UnLockPlayerMovement();
        animator.SetTrigger("deerNoMore");
    }

    public void BackToIdleAnim()
    {
        animator.SetTrigger("IdleState");
    }

    public void PlayerTreeAttack()
    {
        playerMovement.LockPlayerMovement(true);
    }

    public void StartCameraShake(float duration, float xMagnitude, float yMagnitude)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(cameraShake.Shake(duration, xMagnitude, yMagnitude));
        //transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PlayerRestoreHealth(int newHealth)
    {
        health += newHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthScreen();
    }

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthScreen();
        if (health <= 0)
        {
            PlayerDeath();
        }
    }

    private void UpdateHealthScreen()
    {
        print("Hit " + health + "/"+ maxHealth);
        if(health <= halfHealth)
        {
            lowHeathScreen.SetActive(true);
        }
        else
        {
            lowHeathScreen.SetActive(false);
        }
    }

    public void PlayerDeath()
    {
        sceneController.PlayDeathScreen();
    }

    public void TeleportPlayer(Vector3 newLocation, Quaternion playerRotation)
    {
        StartCoroutine(TeleportPlayerAnim(newLocation, playerRotation));
    }

    IEnumerator TeleportPlayerAnim(Vector3 newLocation, Quaternion playerRotation)
    {
        //crossFadeAnimator.SetTrigger("Start");
        crossFadeAnimator.SetTrigger("Start&End");
        yield return new WaitForSeconds(1);
        characterController.enabled = false;
        transform.rotation = playerRotation;
        transform.position = newLocation;
        characterController.enabled = true;
    }

    //cheats
    private void TeleportCheats()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TeleportPlayer(bossZone.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            TeleportPlayer(watchtower.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            TeleportPlayer(oldLadyHouse.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            TeleportPlayer(campSite.position, transform.rotation);
        }
    }
}
