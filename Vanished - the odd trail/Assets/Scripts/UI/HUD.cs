using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;

    public void OpenMessagePanel(string text)
    {
        messagePanel.SetActive(true);
        messageText.text = text;
        
    }

    public void CloseMessagePanel()
    {
        messagePanel.SetActive(false);
    }
}
