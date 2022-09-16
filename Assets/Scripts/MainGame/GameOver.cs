using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField]
    private GameObject gameOverAdd;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        gameOverMenu.SetActive(false);
        gameOverAdd.SetActive(true);
        StartCoroutine(_enableFinishMenu());
    }

    private IEnumerator _enableFinishMenu()
    {
        yield return new WaitForSeconds(3);
        gameOverMenu.SetActive(true);
        gameOverAdd.SetActive(false);
    }

    public void backToMenu()
    {
        gameManager.backToMainMenu();
    }
    public void reloadLevel()
    {
        gameManager.ReloadScene();
    }

    public void skipAD()
    {
        StopAllCoroutines();
        gameOverMenu.SetActive(true);
        gameOverAdd.SetActive(false);
    }
}
