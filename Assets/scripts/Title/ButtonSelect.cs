using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    private Button[] button = new Button[3];

    public void InstantiateExplotion(int ButtonNum)
    {
        var ButtonRect = button[ButtonNum].GetComponent<RectTransform>().rect;
        Vector3 ButtonPos = new Vector3(ButtonRect.position.x, ButtonRect.position.y,0);
        var clone = Instantiate(Explosion, ButtonPos,Quaternion.identity,button[ButtonNum].transform);

        clone.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        clone.GetComponent<RectTransform>().anchoredPosition =  Vector2.zero;
    }
}
