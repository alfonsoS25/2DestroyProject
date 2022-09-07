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
                Attacking();
                break;
            case gameState.GameOver:
                break;
            case gameState.GameClear:
                break;
        }
    }

    private float counter = 0;
    private void Attacking()
    {
        counter += Time.deltaTime;
        if(counter > 5)
        {
            gamestate = gameState.Ilde;
            counter = 0;
            shootTries--;
            if(shootTries <=0)
            {
                CheckGame();
            }

        }
    }
    private void CheckGame()
    {
        if(pointManager.actualPoints < pointManager.maxPoints)
        {
            Debug.Log("not Pass");
        }
        else
        {
            Debug.Log("pass");
        }
    }
}
