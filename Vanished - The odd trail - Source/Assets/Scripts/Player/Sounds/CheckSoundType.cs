using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSoundType : MonoBehaviour
{
    public GameObject outsideSound;
    public GameObject insideSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideSound.SetActive(true);
            outsideSound.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        insideSound.SetActive(false);
        outsideSound.SetActive(true);
    }
}
