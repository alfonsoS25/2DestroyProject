using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBuiling : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    private bool _oneActivation = false;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.childCount ==0 && _oneActivation ==false)
        {
            _gameManager.StartCoroutine(_gameManager.targetDestroyed());
            Debug.Log("destruido");
            _oneActivation = true;
        }
    }
}
