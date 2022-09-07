using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    private Text PointsText;

    [SerializeField]
    private GameObject PointsBar;

    [SerializeField]
    private GameObject BlocksCount;

    [SerializeField]
    private float PointsBarSize = 1;

    [SerializeField]
    private float PointsBarSizeX = 0;

    private float movepositionX = 0;

    private float positiondelay = 0;

    public float maxPoints = 0;

    public int actualPoints = 0;

    public float[] goalPoints = new float[3];

    private void Start()
    {
        for (int i = 0; i < BlocksCount.transform.childCount; i++)
        {
            maxPoints++;
        }

        PointsBarSize = PointsBarSize / maxPoints;
        PointsBar.transform.localScale = new Vector3(0, 1, 0);

        movepositionX = (PointsBar.GetComponent<RectTransform>().sizeDelta.x / 2) / maxPoints;
        Vector3 positionRect = PointsBar.GetComponent<RectTransform>().anchoredPosition;
        positionRect.x = positionRect.x - PointsBar.GetComponent<RectTransform>().sizeDelta.x / 2;
        PointsBar.transform.localPosition = positionRect;
        maxPoints *= 100;

        goalPoints[0] = maxPoints * 0.4f;
        goalPoints[1] = maxPoints * 0.75f;
        goalPoints[2] = maxPoints;
    }
    public void SumPoints(int Points)
    {
        actualPoints += Points;
        PointsText.text = "" + actualPoints;
        updatePointBar();
    }

    void updatePointBar()
    {
        PointsBarSizeX += PointsBarSize;
        PointsBar.transform.localScale = new Vector3(PointsBarSizeX, 1, 0);
        positiondelay += movepositionX;
        Vector3 position = PointsBar.GetComponent<RectTransform>().anchoredPosition;
        position.x = positiondelay - PointsBar.GetComponent<RectTransform>().sizeDelta.x / 2;
        PointsBar.transform.localPosition = position;
    }

    public int CalculateStarts()
    {
        int stars = 0;
        for (int i = 0; i < 3; i++) {

            if (actualPoints >= goalPoints[i])
            {
                stars++;
            }
            else
            {
                break;
            }
        }
        Debug.Log("estrellas fase 1: " + stars);
        return stars;
        
    } 
}


