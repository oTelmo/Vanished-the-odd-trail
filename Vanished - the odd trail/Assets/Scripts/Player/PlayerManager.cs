using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int health;
    public int maxHealth = 2;
    private int halfHealth;

    public CameraShake cameraShake;
    public GameObject lowHeathScreen;
    private SceneController sceneController;
    private PlayerMovement playerMovement;
    private GameObject gameManager;
    private CharacterController characterController;
    private Animator crossFadeAnimator;

    [Header("Items")]
    public bool hasBossItems = true;

    private Animator animator;
    [Header("Animations")]
    public bool deerAttackRunning = false;
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        halfHealth = (health / maxHealth);
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        gameManager = GameObject.FindWithTag("GameManager");
        sceneController = gameManager.GetComponent<SceneController>();
        crossFadeAnimator = gameManager.transform.GetChild(0).gameObject.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        print("Hit " + health + "/"+ halfHealth);
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
}
