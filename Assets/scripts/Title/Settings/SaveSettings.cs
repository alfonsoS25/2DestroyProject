using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveSettings : MonoBehaviour, IPointerUpHandler
{
    [SerializeField]
    private Settings sett;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        sett.SaveBgm();
        Debug.Log("arriva");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
