using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsGenerator : MonoBehaviour
{

    [SerializeField] private int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpaceing;

    Transform[] dotsList;

    public 

    Vector2 pos;

    float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        PrepareDots();
        Hide();
        
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        for(int i = 0; i < dotsNumber;i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;
        }
    }

    public void updateDots(Vector3 ballPos , Vector2 forceApplied)
    {
        timeStamp = dotSpaceing;
        for(int i = 0; i < dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude*timeStamp*timeStamp)/2f;
            dotsList[i].position = pos;
            timeStamp += dotSpaceing;
        }
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }
    public void Hide()
    {
        dotsParent.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
