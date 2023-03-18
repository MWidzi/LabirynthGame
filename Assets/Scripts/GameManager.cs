using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] int timeToEnd;

    bool GamePause = false;

    bool endGame = false;

    bool Win = false;

    private void Start()
    {
        if(gameManager = null)
        {
            gameManager = this;
        }

        InvokeRepeating("Stoper", 2, 1);

        if (timeToEnd <= 0) timeToEnd = 100;
    }

    private void Update()
    {
        PauseCheck();
    }

    void Stoper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame) EndGame();
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume game");
        Time.timeScale = 1f;
        GamePause = false;
    }

    void PauseCheck()
    {
        if(Input.GetKey(KeyCode.P))
        {
            if (GamePause) ResumeGame();
            else PauseGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stoper");
        if (Win) Debug.Log("Wygrałeś");
        else Debug.Log("Przegrałeś");
    }
}
