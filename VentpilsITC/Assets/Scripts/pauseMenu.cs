using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObject;

    public void onPause()
    {
        pauseMenuObject.SetActive(true);
    }
    public void onResumeGame()
    {
        pauseMenuObject.SetActive(false);
    }
    public void onExit()
    {
        Application.Quit();
    }
    public void onRestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
