using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject BrokenButton;

    [SerializeField]
    private Transform UiRoot;

    [SerializeField]
    private string[] ListOfScreens;

    [SerializeField]
    private Material[] ExplosionMaterial;

    [SerializeField]
    private Texture[] ExplosionTexture1;

    [SerializeField]
    private Texture[] ExplosionTexture2;

    [SerializeField]
    private Texture[] ExplosionTexture3;

    [SerializeField]
    private Texture[] ExplosionTexture4;

    private void Start()
    {
        SetMaterial(0);
    }
    public void StringToInt(string frase)
    {
        for (int i = 0; i < ListOfScreens.Length; i++)
        {
            if (ListOfScreens[i].Contains(frase))
            {
                SetMaterial(i);
                GenerateExplosion(i);
            }
        }
    }

    public void GenerateExplosion(int ExplosionNum)
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 InputPos = Input.mousePosition - Pos;
        Vector3 ExplosionPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var Clone = Instantiate(BrokenButton, ExplosionPos, Quaternion.identity, UiRoot);
        Clone.transform.position = ExplosionPos;
    }

    private void SetMaterial(int MaterialNum)
    {
        ExplosionMaterial[0].mainTexture = ExplosionTexture1[MaterialNum];
        ExplosionMaterial[1].mainTexture = ExplosionTexture2[MaterialNum];
        ExplosionMaterial[2].mainTexture = ExplosionTexture3[MaterialNum];
        ExplosionMaterial[3].mainTexture = ExplosionTexture4[MaterialNum];
    }

}

