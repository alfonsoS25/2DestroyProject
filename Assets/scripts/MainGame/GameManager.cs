using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PointManager pointManager;
    public enum gameState
    {
        Ilde,
        Attacking,
        GameOver,
        GameClear,
    }

    public gameState gamestate;

    private bool isDecided = false;

    [SerializeField]
    private int shootTries;

    // Start is called before the first frame update
    void Start()
    {
        gamestate = gameState.Ilde;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(gamestate);
        switch (gamestate)
        {
            case gameState.Ilde:
                break;
            case gameState.Attacking:
                attacking();
                break;
            case gameState.GameOver:
                gameOver();
                break;
            case gameState.GameClear:
                gameClear();
                break;
        }
    }

    private float counter = 0;
    private void attacking()
    {
        if (!isDecided)
        {
            counter += Time.deltaTime;
            if (counter > 5)
            {
                gamestate = gameState.Ilde;
                counter = 0;
                shootTries--;
                if (shootTries <= 0)
                {
                    checkGame();
                }
            }
        }
    }
    private void checkGame()
    {
        if(pointManager.actualPoints < pointManager.maxPoints)
        {
            gamestate = gameState.GameOver;
        }
        else
        {
            gamestate = gameState.GameClear;
        }
    }

    private void gameOver()
    {
        Debug.Log("not Pass");
        isDecided = true;
    }
    private void gameClear()
    {
        Debug.Log("Pass");
        isDecided = true;
    }
}
