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
    private List<RectTransform> GeneratedShadowList;
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
    }

    public void GenerateShadowScreen(RectTransform rect)        //指定されたポジションに影を制作する
    {
        Debug.Log("Generated");
        /*bool Generate = true;                 //デバッグのために全て消されています
        Debug.Log("PassTest");
        Debug.Log("to generate: "+ rect.rect);

        int i = 0;
        foreach(RectTransform rectt in GeneratedShadowList)
        {
            Debug.Log("generated :" + GeneratedShadowList[i].rect);
            if (rect.rect == GeneratedShadowList[i].rect)
            {
                Debug.Log("Ya");
                Generate = false;
            }
            i++;
        }
        if (Generate)
        {*/
            /*Debug.Log("Save");
            var clone = Instantiate(Shadow, rect.position, Quaternion.identity, rect.transform);
            clone.GetComponent<RectTransform>().sizeDelta = rect.sizeDelta;
            GeneratedShadowList.Add(clone.GetComponent<RectTransform>());*/
        //}
        /*
        for (int i = 0; i < GeneratedShadowList.Count; i++)
        {
            Debug.Log("generated :" + GeneratedShadowList[i].rect);
            if (rect.rect == GeneratedShadowList[i].rect)
            {
                Debug.Log("Ya");
                Generate = false;
            }
        }
        if (Generate)
        {
            Debug.Log("Save");
            var clone = Instantiate(Shadow, rect.position, Quaternion.identity, rect.transform);
            clone.GetComponent<RectTransform>().sizeDelta = rect.sizeDelta;
            GeneratedShadowList.Add(clone.GetComponent<RectTransform>());
        }*/
    }
}
