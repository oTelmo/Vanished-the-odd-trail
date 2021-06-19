using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStepsSound : MonoBehaviour
{
    public CharacterController cc;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 0 && audioSource.isPlaying == false)
        {
            //audioSource.volume = Random.Range(.8f, 1f);
            audioSource.pitch = Random.Range(.8f, 1.1f);
            audioSource.Play();
        }
    }
}
