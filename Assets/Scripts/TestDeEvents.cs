using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDeEvents : MonoBehaviour
{

    /*Esto lo pongo para despues hacerlo prolijo pero ya tenerlo mas o menos hecho y ganas tiempo
     aca iria todo lo del juego en si, como ganar, perder, particulas, score, bla*/
    // Use this for initialization

    public float score;
    public float _totalScore;
    public bool _win;
    public bool _lose;


    private void Awake()
    {
        EventManager.SubscribeToEvent(EventType.Game_win, Win);
        EventManager.SubscribeToEvent(EventType.Game_lose, Lose);
        EventManager.SubscribeToEvent(EventType.Game_score, ScoreUpdated);
    }
    void Update()
    {
        _totalScore = score;
    }

    #region win/lose
    //Despues ponemos las condiciones, supongo que se van a basar en perder todas las vidas y matar el final boss

    private void Win(params object[] param)
    {
        if (_win)
        {          
            //SceneManager.LoadScene("Win");
            Debug.Log("ganast perri");

        }
    }
    private void Lose(params object[] param)
    {
        if (_lose)
        {
            Debug.Log("Looooooser");
            //SceneManager.LoadScene("GameOver");
        }
    }
    #endregion

    #region score
    private void ScoreUpdated(params object[] param)
    {
        var currentScore = (float)param[0];
        var totalScore = (float)param[1];
        Debug.Log("Total Score" + currentScore + "el coso" + (currentScore/totalScore));
    }
    #endregion
}
