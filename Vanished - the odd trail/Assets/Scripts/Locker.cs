﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Locker : MonoBehaviour, IInteractable
{

    public GameObject codePanel, wrongPin, listOfPeople;
    public TextMeshProUGUI codeText;
    public GameObject hud;
    
    private string codeTextValue = "";
    private bool isLockerOpened = false;
    private bool isActive = false;
    private bool isOpen = false;

    private PlayerMovement playerMovement;

    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 100f;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        isOpen = false;
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if (isLockerOpened)
        {
            codePanel.SetActive(false);
            listOfPeople.SetActive(true);
        }

        if (codeTextValue == "2000")
        {
            isLockerOpened = true;
        } 
        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
            StartCoroutine(SetWrongPinActive());
        }
    }

    IEnumerator SetWrongPinActive()
    {
        wrongPin.SetActive(true);
        yield return new WaitForSeconds(2);
        wrongPin.SetActive(false);
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

    public void OpenLocker()
    {       
        codePanel.SetActive(true);
        playerMovement.LockPlayerMovement(true);
        Cursor.lockState = CursorLockMode.None;
        isOpen = true;
    }

    public void CloseLocker()
    {
        codePanel.SetActive(false);
        listOfPeople.SetActive(false);
        isLockerOpened = false;
        playerMovement.UnLockPlayerMovement();
        Cursor.lockState = CursorLockMode.Locked;
        isOpen = false;
    }

    public void OnStartInteraction()
    {
        Debug.Log("Interaction with " + gameObject.name);
        isActive = true;
        hud.GetComponent<HUD>().OpenMessagePanel("Press F to open locker");
    }

    public void OnInteraction()
    {
        if (isActive)
        {
            if (isOpen)
            {
                CloseLocker();
            }
            else
            {
                OpenLocker();
            }
        }
    }

    public void OnEndInteraction()
    {
        isActive = false;
        hud.GetComponent<HUD>().CloseMessagePanel();
    }
}
