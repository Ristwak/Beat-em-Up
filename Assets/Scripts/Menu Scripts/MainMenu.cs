using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject OptionsMenu;
    public GameObject mainMenu;
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnQuitButton()
    {
        Debug.Log("Quitting Game.......");
        Application.Quit();
    }

    public void OnOptionsButton()
    {
        OptionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnBackButton()
    {
        OptionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
