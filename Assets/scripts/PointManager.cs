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



    private void Start()
    {
        float BarSize = 0;
        for(int i = 0; i < BlocksCount.transform.childCount;i++)
        {
            BarSize++;
        }
        PointsBarSize = PointsBarSize / BarSize;
        Debug.Log(PointsBarSize);
        PointsBar.transform.localScale = new Vector3(0,1,0);

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
    }

}
