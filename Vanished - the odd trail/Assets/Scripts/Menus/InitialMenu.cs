using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
