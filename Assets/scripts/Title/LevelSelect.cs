using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelButton;

    [SerializeField]
    private RectTransform RectButton;

    [SerializeField]
    private Transform UI;

    private MainMenu mainMenu;

    [SerializeField]
    private int LevelPass = 0;
    Dictionary<string, int> LevelDirectory = new Dictionary<string, int>();

    public void GenerateMenu()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MenuManager").gameObject.GetComponent<MainMenu>();
        MakeMenu();
    }

    private void MakeMenu()
    {
        int Counter = 0;
        Vector3 offset = new Vector3(-1300,600,0);
        offset.z = -10;

        for(int i = 0; i < 3; i++)
        {   
            offset.y -= 300;
            for(int f = 0; f < 4; f++)
            {
                int levelStack = new int();
                levelStack = Counter;
                
                offset.x += 500;
                var buttonClone = Instantiate(LevelButton, Vector3.zero, Quaternion.identity, UI);
                buttonClone.GetComponent<RectTransform>().anchoredPosition3D = offset;
                buttonClone.GetComponent<Button>().onClick.AddListener(delegate { GenerateLevel("Level" + levelStack); });//onClick.AddListener(hola22);
                buttonClone.name = "Level" + Counter;
                LevelDirectory.Add(buttonClone.name, Counter);
                if (Counter >= LevelPass)
                {
                    mainMenu.GenerateShadowScreen(buttonClone);
                }
                Counter++;
            }
            offset.x = -1300;
        }
    }
    public void GenerateLevel(string Level)
    {
        int creator=0;
        LevelDirectory.TryGetValue(Level,out creator);
        Debug.Log("Generated: "+ creator);
    }

    public void resetDictionary()
    {
        LevelDirectory.Clear();
    }

}
