using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLvl1()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void PlayLvl2()
    {
        SceneManager.LoadSceneAsync("Level 2");
    }

    public void PlayLvl3()
    {
        SceneManager.LoadSceneAsync("Level 3");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void EndScreen()
    {
        SceneManager.LoadSceneAsync("End Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
