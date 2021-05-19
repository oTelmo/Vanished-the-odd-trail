using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemInteraction : MonoBehaviour, IInteractable
{
    private GameObject hud;

    //IInteractable related
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindWithTag("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        hud.GetComponent<HUD>().OpenMessagePanel("Press F to go inside.");
    }

    public void OnInteraction()
    {
        
    }

    public void OnEndInteraction()
    {
        Debug.Log("Stopped interaction with " + gameObject.name);
        hud.GetComponent<HUD>().CloseMessagePanel();
    }
}
