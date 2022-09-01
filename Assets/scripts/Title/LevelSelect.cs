using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelButton;

    [SerializeField]
    private RectTransform RectButton;

    [SerializeField]
    private Transform UI;

    private MainMenu mainMenu;

    public void GenerateMenu()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MenuManager").gameObject.GetComponent<MainMenu>();
        MakeMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeMenu()
    {
        Vector3 offset = new Vector3(-1300,600,0);
        offset.z = -10;
        for(int i = 0; i < 3; i++)
        {
            offset.y -= 300;
            for(int f = 0; f < 4; f++)
            {
                offset.x += 500;
                var ButtonClone = Instantiate(LevelButton, Vector3.zero, Quaternion.identity, UI);

                ButtonClone.GetComponent<RectTransform>().anchoredPosition3D = offset;
                mainMenu.GenerateShadowScreen(ButtonClone);
            }
            offset.x = -1300;
        }
    }
    
}
