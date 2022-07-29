using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    private Text PointsText;

    [SerializeField] private int PointNum = 0;

    public void SumPoints(int Points)
    {
        PointNum += Points;
        PointsText.text = ""+PointNum;
    }

}
