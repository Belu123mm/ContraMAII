using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int _continue = 3;

    public void GoToGame()
    {
        if (_continue > 0)
        {
            // _continue--;
            //  DontDestroyOnLoad(_continue);
            SceneManager.LoadScene("main");
        }
    }
    public void End()
    {
        SceneManager.LoadScene("Start");
    }
}
