using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject PlayButton;
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject LevelSelect;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject SkillTree;

    [SerializeField] private List<GameObject> ListOfGamen = new List<GameObject>();

    [Header("DarkSprites")]
    [SerializeField]
    private GameObject Shadow;

    [SerializeField]
    private List<Vector3> GeneratedShadowList;
    [SerializeField]
    private List<GameObject> ShadowGameObjectList;
    private void AddMenu()
    {
        ListOfGamen.Add(PlayButton);
        ListOfGamen.Add(MainScreen);
        ListOfGamen.Add(LevelSelect);
        ListOfGamen.Add(Settings);
        ListOfGamen.Add(SkillTree);
    }
    void Start()
    {
        AddMenu();
        SelectGamen(0);
    }

    public void SelectGamen(int Index)
    {
        for(int i = 0; i < ListOfGamen.Count;i++)
        {
            if(i != Index)
            {
                ListOfGamen[i].SetActive(false);
            }
            else 
            { 
                ListOfGamen[i].SetActive(true);
            }
        }
        if(GeneratedShadowList.Count >=1)
        {
            for(int i = 0; i < GeneratedShadowList.Count;i++)
            {
                Destroy(ShadowGameObjectList[i]);
            }
            ShadowGameObjectList.Clear();
            GeneratedShadowList.Clear();
        }
    }

    public void GenerateShadowScreen(GameObject cuboputo)        //指定されたポジションに影を制作する
    {
        //Debug.Log("Generated: " + cuboputo.name + " on: " + cuboputo.GetComponent<Transform>().position);
        RectTransform cuboSize = cuboputo.GetComponent<RectTransform>();
        Vector3 CuboPos = cuboputo.GetComponent<Transform>().position;
        bool Generate = true;

        for (int i = 0; i < GeneratedShadowList.Count; i++)
        {
            if (CuboPos == GeneratedShadowList[i])
            {
                Debug.Log("not generated");
                Generate = false;
            }
            else
            {
                Debug.Log("generated :" + GeneratedShadowList[i]);
            }
        }
        if (Generate)
        {
            var clone = Instantiate(Shadow, CuboPos, Quaternion.identity,cuboputo.transform);
            clone.GetComponent<RectTransform>().sizeDelta = cuboSize.sizeDelta;
            GeneratedShadowList.Add(CuboPos);
            ShadowGameObjectList.Add(clone);
        }
    }
}
