using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player stats")]
    public float playerHealth = 3;
    [Header("Player stats")]
    public CameraShake cameraShake;
    public MeshRenderer childMeshRenderer;
    private SceneController sceneController;
    private PlayerMovement playerMovement;
    private GameObject gameManager;
    private MouseLook mouseLook;

    [Header("Animations")]
    private Animator animator;
    public bool deerAttackRunning = false;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        gameManager = GameObject.FindWithTag("GameManager");
        sceneController = gameManager.GetComponent<SceneController>();
        mouseLook = transform.GetChild(1).GetComponent<MouseLook>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        sceneController.PlayDeathScreen();
    }

    public void PlayerDeerAttack()
    {
        if (deerAttackRunning == false)
        {
            deerAttackRunning = true;
            playerMovement.playerCaught = true;
            animator.SetTrigger("deerAttack");
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeerAttack"))
            {
                //animator.SetTrigger("deerNoMore");
                //animator.SetInteger("deerAttackState", 2);
            }
        }
    }

    public void PlayerDeerStoppedAttack()
    {
        deerAttackRunning = false;
        playerMovement.playerCaught = false;
        mouseLook.UnLockPlayerCamera();
        animator.SetTrigger("deerNoMore");
    }

    public void StartCameraShake(float duration, float xMagnitude, float yMagnitude)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(cameraShake.Shake(duration, xMagnitude, yMagnitude));
        //transform.GetChild(0).gameObject.SetActive(true);
    }

}
