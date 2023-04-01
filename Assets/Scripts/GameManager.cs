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

    public int RedKey = 0;
    public int GreenKey = 0;
    public int GoldKey = 0;

    public int Points = 0;


    public void AddPoints(int p)
    {
        Debug.Log("AddPoints");
        Points += p;
    }

    public void AddTime(int t)
    {
        timeToEnd += t;
    }

    public void FreezeTime(int f)
    {
        Debug.Log("Freeze");
        CancelInvoke("Stoper");
        InvokeRepeating("Stoper", f, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Red) RedKey++;
        if (color == KeyColor.Green) GreenKey++;
        if (color == KeyColor.Gold) GoldKey++;
    }

    public void PickedUpCheck()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Aktualny czas:" + timeToEnd);
            Debug.Log("Red: " + RedKey + "Green: " + GreenKey + "Gold: " + GoldKey);
            Debug.Log("Punkty: " + Points);
        }
    }

    private void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        InvokeRepeating("Stoper", 2, 1);

        if (timeToEnd <= 0) timeToEnd = 100;
    }

    private void Update()
    {
        PauseCheck();
        PickedUpCheck();
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
