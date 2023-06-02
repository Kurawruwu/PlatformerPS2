using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
