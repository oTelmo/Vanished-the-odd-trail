using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Locker : MonoBehaviour
{

    public GameObject codePanel, wrongPin, listOfPeople;
    public TextMeshProUGUI codeText;
    private string codeTextValue = "";

    public bool isLockerOpened = false;
    private bool isActive = false;
    private bool isOpen = false;
    public GameObject hud;


    private PlayerMovement playerMovement;

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

        /*if (isLockerOpened)
        {
            codePanel.SetActive(false);
        }*/

        if (codeTextValue == "1994")
        {
            isLockerOpened = true;
            listOfPeople.SetActive(true);
        } 
        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
            StartCoroutine(SetWrongPinActive());
        }
        if (isActive && Input.GetKeyDown(KeyCode.F))
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isLockerOpened)
        {
            isActive = true;
            hud.GetComponent<HUD>().OpenMessagePanel("Press F to open locker");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
            hud.GetComponent<HUD>().CloseMessagePanel();
        }
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
        playerMovement.UnLockPlayerMovement();
        Cursor.lockState = CursorLockMode.Locked;
        isOpen = false;
    }
}
