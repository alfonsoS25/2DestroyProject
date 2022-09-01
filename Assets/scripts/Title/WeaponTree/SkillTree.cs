using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuUI;

    [SerializeField]
    private Scrollbar scrollbar;

    [SerializeField]
    private float YPos;

    private MainMenu mainMenu;
/*
    [SerializeField]
    private GameObject[] SkillsSlots;
    [SerializeField]
    private bool[] EnabledSkill;*/


    [System.Serializable]
    public struct SkillTreeBlock{
        public GameObject BloqueRePuto;
        public bool IsBlockArchived;
        public string BlockName;
    };

    [SerializeField]
    public SkillTreeBlock[] Block = new SkillTreeBlock[5];

    void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MenuManager").gameObject.GetComponent<MainMenu>();
    }

    public void LoadMenu()
    {
        translateMenu();
        LoadLevel();
    }
    public void translateMenu()
    {
        Vector3 position = Vector3.zero;
        position.x =-800 + (1600 * scrollbar.value);
        position.y = YPos;
        MenuUI.GetComponent<RectTransform>().anchoredPosition3D = position;
    }


    public  void SaveLevel()
    {
        
        foreach (SkillTreeBlock STB in Block)
        {
            int BooleanInt = STB.IsBlockArchived ? 1:0 ;
            PlayerPrefs.SetInt(STB.BlockName, BooleanInt);
        }
    }

    public void LoadLevel()
    {
        int i = 0;
        foreach (SkillTreeBlock STB in Block)
        {
            bool blockLoad = PlayerPrefs.GetInt(STB.BlockName) == 1 ? true : false;
            Block[i].IsBlockArchived = blockLoad;
            i++;
        }
        UpdateLevels();
    }

    public void UpdateLevels()     //全てのブロックを確認して、IsBlockArchivedのブールがfalseだったら、その上に影を作る
    {
        for (int i = 0; i < Block.Length; i++)
        {
            string hola = "";
            if (Block[i].IsBlockArchived)
            {
                hola = "yay";
            }
            else
            {
                hola = "noooo";
                Debug.Log(i);
                mainMenu.GenerateShadowScreen(Block[i].BloqueRePuto);  //この行が一回目以外飛ばされてしまいます
                //Debug.Log(Block[i].BlockName);
            }
            Block[i].BloqueRePuto.GetComponentInChildren<Text>().text = hola;
        }
    }
    public void SwichBool(int number)
    {
        Block[number].IsBlockArchived = !Block[number].IsBlockArchived; 
        UpdateLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
