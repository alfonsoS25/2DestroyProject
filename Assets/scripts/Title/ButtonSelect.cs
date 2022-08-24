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


    private void Start()
    {
    }
    public void InstantiateExplotion(int ButtonNum)
    {
       // ExplosionHolder.SetActive(true);
        var ButtonRect = button[ButtonNum].GetComponent<RectTransform>().rect;
        Vector3 ButtonPos = new Vector3(ButtonRect.position.x, ButtonRect.position.y,0);
        //var clone = Instantiate(Explosion, ButtonPos,Quaternion.identity,button[ButtonNum].transform);

       // ExplosionHolder.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        //ExplosionHolder.GetComponent<RectTransform>().anchoredPosition =  Vector2.zero;
    }
}
