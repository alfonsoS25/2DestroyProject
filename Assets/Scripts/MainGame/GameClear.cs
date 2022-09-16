using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField]
    private GameObject gameClearMenu;
    [SerializeField]
    private GameObject gameClearAdd;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        gameClearMenu.SetActive(false);
        gameClearAdd.SetActive(true);
        StartCoroutine(_enableFinishMenu());
    }

    private IEnumerator _enableFinishMenu()
    {
        yield return new WaitForSeconds(3);
        gameClearMenu.SetActive(true);
        gameClearAdd.SetActive(false);
    }
    public void nextLevel()
    {
        gameManager.loadNextLevel();
    }
    public void backToMenu()
    {
        gameManager.backToMainMenu();
    }

    public void skipAD()
    {
        StopAllCoroutines();
        gameClearMenu.SetActive(true);
        gameClearAdd.SetActive(false);
    }
}
