using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Invoke("RealGame", 1);
    }

    public void RealGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Invoke("RealQuit", 1);
    }

    public void RealQuit()
    {
        Application.Quit();
    }
}
