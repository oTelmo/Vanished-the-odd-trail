using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void PlayDeathScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("DeathScene");
    }

    public void LoadMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");

    }
    public void WonGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("WonScene");
    }


}
