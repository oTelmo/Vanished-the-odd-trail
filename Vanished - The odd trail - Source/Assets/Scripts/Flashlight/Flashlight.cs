using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool flashlightEnabled;
    public GameObject flashLight;
    private FlashlightInteraction pickedUpBool;


    // Start is called before the first frame update
    void Start()
    {
        pickedUpBool = GameObject.FindWithTag("Flashlight").GetComponent<FlashlightInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUpBool.pickedUp)
        {
            if (Input.GetKeyDown(KeyCode.X))
                flashlightEnabled = !flashlightEnabled;

            if (flashlightEnabled)
            {
                flashLight.SetActive(true);
            }
            else
            {
                flashLight.SetActive(false);
            }
        }
    }
}
