using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject opScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameToggle();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            opScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            opScreen.SetActive(false);
        }
    }

    public void GameToggle()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }

    public void RealQuit()
    {
        Application.Quit();
    }
}
