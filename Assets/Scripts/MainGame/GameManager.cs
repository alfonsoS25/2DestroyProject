using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Text shootCounter;
    [SerializeField]
    private PointManager pointManager;
    public enum gameState
    {
        Ilde,
        Attacking,
        GameOver,
        GameClear,
        SelectingWeapon,
        onText,
        onTutorial,
    }


    public gameState gamestate;

    private bool isDecided = false;

    [SerializeField]
    private int shootTries;

    [SerializeField]
    private Transform stageRoot;
    [SerializeField]
    private Transform uIRoot;

    [SerializeField]
    private Animator uiAnim;

    [SerializeField]
    private GameObject clearMenu;
    [SerializeField]
    private GameObject defeatMenu;

    private float counter = 0;

    [Header("Tutorial")]

    [SerializeField]
    private bool isTutorial = false;

    private string writeText = "";

    [SerializeField]
    private GameObject tutorialLevel;

    [SerializeField]
    private GameObject textSample;

    [SerializeField]
    private TextMeshProUGUI textToWrite;

    [SerializeField]
    private int tutorialNumber;

    [SerializeField]
    private GameObject[] targets = null;

    [SerializeField]
    private Vector3[] targetPos = null;

    private int targetID;

    [SerializeField]
    private GameObject _pressToContinueTab;

    public int getTargetID
    {
        get { targetID++; return targetID-1;}
        private set { targetID = value; }
    }

    public int targetCounter = 0;


    // Start is called before the first frame update
    private void Awake()
    {
        gamestate = gameState.Ilde;
        LoadScene();
        pointManager.generatePointSystem();
    }
    void Start()
    {
        if (isTutorial)
        {
            StartCoroutine(generateText("Welcome to 2Destroy!", false));
        }
        uiAnim.Play("Start");
    }

    public void LoadScene()
    {
        Vector3 stagePos = new Vector3(transform.position.x, transform.position.y, 60);
        if (isTutorial)
        {
            shootTries = 999;
            //Instantiate(tutorialLevel, stagePos, Quaternion.identity, stageRoot);
            return;
        }
        int randomnum = PlayerPrefs.GetInt("levelToPlay");
        int randomnum2 = randomnum / 3;
        randomnum = randomnum % 3;
        Debug.Log("World" + randomnum2 + "/" + "Stage" + randomnum);
        var levelClone = Instantiate(Resources.Load<GameObject>("World" + randomnum2+ "/" + "Stage"+ randomnum), stagePos,Quaternion.identity,stageRoot);
        shootCounter.text = "shoots left: " + shootTries;
    }
    public void ReloadScene()
    {
        StartCoroutine(reloadScene());
    }

    public void loadNextLevel()
    {
        int level = PlayerPrefs.GetInt("levelToPlay");
        level++;
        PlayerPrefs.SetInt("levelToPlay", level);
        StartCoroutine(reloadScene());
    } 
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTutorial)
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
                case gameState.onText:
                    break;
                case gameState.onTutorial:
                    onTutorialPhase();
                    break;
            }
        }
    }
    private void Update()
    {
        
        if (isTutorial)
        {
            switch (gamestate)
            {
                case gameState.Attacking:
                    attacking();
                    break;
                case gameState.onText:
                    break;
                case gameState.onTutorial:
                    onTutorialPhase();
                    break;
            }
        }
    }

    private void onTutorialPhase()
    {
        counter += Time.deltaTime;
        if (counter > 2)
        { 
            if(Input.GetMouseButtonDown(0))
            {
                tutorialNumber++;
                switch (tutorialNumber)
                {
                    case 1:
                        StartCoroutine(generateText("Your Goal Is To Destroy My Enemy Constructions", false));
                        break;
                    case 2:
                        StartCoroutine(generateText("Lets Try Destroying That Dummy", true));
                        GenerateTarget(0);
                        break;
                    case 3:
                        StartCoroutine(generateText("Nice Shot!", false));
                        break;
                    case 4:
                        StartCoroutine(generateText("There are a lot of weapons to try", false));
                        break;
                    case 5:
                        StartCoroutine(generateText("check the weapon box behind me, you can take what you want this time", false));
                        break;
                    case 6:
                        StartCoroutine(generateText("now lets destroy them!", false));
                      
                        break;
                }
            }
        }
    }
    private void showPressToContinue()
    {
        _pressToContinueTab.SetActive(true);
    }
    public IEnumerator targetDestroyed()
    {
        gamestate = gameState.onTutorial;
        yield return new WaitForSeconds(1.4f);
        showPressToContinue();
    }
    private void attacking()
    {
        counter += Time.deltaTime;
        if (counter > 0.3f)//3)
        {
            
            gamestate = gameState.Ilde;
            
            counter = 0;
            shootTries--;
            shootCounter.text = "shoots left: " + shootTries;
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

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    private void gameOver()
    {
        isDecided = true;
        Instantiate(defeatMenu, uIRoot.transform.position, Quaternion.identity, uIRoot);
    }
    private IEnumerator reloadScene()
    {
        uiAnim.Play("Leave");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main");
    }

    private void gameClear()
    {
        float Stars = 0;
        Stars = pointManager.CalculateStarts();
        Debug.Log(Stars);
        isDecided = true;
        Instantiate(clearMenu, uIRoot.transform.position, Quaternion.identity,uIRoot);
    }

    private IEnumerator generateText(string textToShow,bool IsAttackNext)
    {
        _pressToContinueTab.SetActive(false);
        gamestate = gameState.onText;
        var clone = Instantiate(textSample, player.transform.position, Quaternion.identity, uIRoot);
        textToWrite = clone.GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < textToShow.Length; i++)
        {
            writeText += textToShow[i];
            textToWrite.text = writeText;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));
        }
        writeText = "";
        textToWrite = null;
        Destroy(clone, 1f);
        if (IsAttackNext)
        {
            gamestate = gameState.Ilde;
        }
        else
        {
            gamestate = gameState.onTutorial;
            _pressToContinueTab.SetActive(true);
        }
    }
    private void GenerateTarget(int target)
    { 
        switch(target)
        {
            case 0:Instantiate(targets[0], targetPos[0], Quaternion.identity);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
        }
    }

}
