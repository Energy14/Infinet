using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpToGame : MonoBehaviour
{
    private float targetTime = 9.0f;


    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
