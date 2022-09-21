using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsGenerator : MonoBehaviour
{

    [SerializeField] private float dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpaceing;
    

    Transform[] dotsList;

    public 

    Vector2 pos;

    float timeStamp;

    [SerializeField]
    private float fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = dotsNumber / dotsNumber / dotsNumber;
        PrepareDots();
        Hide();
    }

    void PrepareDots()
    {
        dotsList = new Transform[(int)dotsNumber];
        for(int i = 0; i < dotsNumber;i++)
        {
            var Generated = Instantiate(dotPrefab, null);
            Generated.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - ( fade*i));
            dotsList[i] = Generated.transform;
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
