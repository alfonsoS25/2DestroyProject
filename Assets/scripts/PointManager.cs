using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    private Text PointsText;

    [SerializeField] private int PointNum = 0;

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

    private void Start()
    {
        float BarSize = 0;
        for(int i = 0; i < BlocksCount.transform.childCount;i++)
        {
            BarSize++;
        }

        PointsBarSize = PointsBarSize / BarSize;
        PointsBar.transform.localScale = new Vector3(0,1,0);

        movepositionX = (PointsBar.GetComponent<RectTransform>().sizeDelta.x / 2) / BarSize;
        Vector3 positionRect = PointsBar.GetComponent<RectTransform>().anchoredPosition;
        positionRect.x = positionRect.x - PointsBar.GetComponent<RectTransform>().sizeDelta.x / 2;
        PointsBar.transform.localPosition = positionRect;

    }
    public void SumPoints(int Points)
    {
        PointNum += Points;
        PointsText.text = ""+PointNum;
        updatePointBar();
    }

    void updatePointBar()
    {
        PointsBarSizeX += PointsBarSize;
        PointsBar.transform.localScale = new Vector3(PointsBarSizeX, 1, 0);
        positiondelay+= movepositionX;
        Vector3 position = PointsBar.GetComponent<RectTransform>().anchoredPosition;
        position.x = positiondelay - PointsBar.GetComponent<RectTransform>().sizeDelta.x / 2;
        PointsBar.transform.localPosition = position;
    }

}
