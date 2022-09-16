using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField]
    private GameObject gameClearMenu;
    [SerializeField]
    private GameObject gameClearAdd;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
