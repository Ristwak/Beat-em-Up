using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainMenu : MonoBehaviour
{
    [Header("All Menu")]
    public GameObject pauseMenuUI;
    public GameObject endGameMenuUI;
    public static bool GameIsStopped = false;

    public void home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void restart()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void OnQuitButton()
    {
        Debug.Log("Quitting Game.......");
        Application.Quit();
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsStopped = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsStopped = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsStopped)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
