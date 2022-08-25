using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject[] BrokenButton;

    [SerializeField]
    private Transform UiRoot;

    [SerializeField]
    private string[] ListOfScreens;


    public void StringToInt(string frase)
    {
        for (int i = 0; i < ListOfScreens.Length; i++)
        {
            if (ListOfScreens[i].Contains(frase))
            {
                GenerateExplosion(i);
            }
        }
    }

    public void GenerateExplosion(int ExplosionNum)
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 InputPos = Input.mousePosition - Pos;
        Vector3 ExplosionPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var Clone = Instantiate(BrokenButton[ExplosionNum], ExplosionPos, Quaternion.identity, UiRoot);
        Clone.transform.position = ExplosionPos;
    }

}

