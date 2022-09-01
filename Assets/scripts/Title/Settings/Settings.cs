using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField]
    private Scrollbar BGMScroll;
    [SerializeField]
    private Scrollbar SEScroll;

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void BGMSetter()
    {
        float BGMValue;
        BGMValue = BGMScroll.value;
        Debug.Log(BGMValue);
    }

    public void SaveBgm()
    {
        Debug.Log("SaveBGM");
    }
}
