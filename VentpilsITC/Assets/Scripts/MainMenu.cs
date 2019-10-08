using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CreateUniverse ()
    {
        SceneManager.LoadScene("BigBang");
    }

    public void ExitGame ()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }
}
