using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float playerHealth = 3;
    public CameraShake cameraShake;
    public MeshRenderer childMeshRenderer;
    public SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void StartCameraShake(float duration, float xMagnitude, float yMagnitude)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(cameraShake.Shake(duration, xMagnitude, yMagnitude));
        //transform.GetChild(0).gameObject.SetActive(true);
    }

}
