using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 3;

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

    }

}
