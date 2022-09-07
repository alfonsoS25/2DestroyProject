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
        if (!isDecided)
        {
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
    }

    private float counter = 0;
    private void attacking()
    {
        counter += Time.deltaTime;
        if (counter > 2)
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
    private void checkGame()
    {
        if(pointManager.actualPoints < pointManager.goalPoints[0])
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
        float Stars = 0;
        Stars = pointManager.CalculateStarts();
        Debug.Log(pointManager.actualPoints);
        Debug.Log(Stars);
        isDecided = true;
    }
}