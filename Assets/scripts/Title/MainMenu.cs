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


    void Start()
    {
        AddMenu();
        SelectGamen(0);
    }

    private void AddMenu()
    {
        ListOfGamen.Add(PlayButton);
        ListOfGamen.Add(MainScreen);
        ListOfGamen.Add(LevelSelect);
        ListOfGamen.Add(Settings);
        ListOfGamen.Add(SkillTree);
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
}
