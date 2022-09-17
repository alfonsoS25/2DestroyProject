using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private int id;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        id = gameManager.getTargetID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
