using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialPhase;

    [SerializeField]
    private Animator uiAnim;

    [SerializeField]
    private GameObject clearMenu;

    void Start()
    {
        Instantiate(tutorialPhase, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
