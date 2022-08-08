using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;

    public void InstantiateExplotion()
    {
        var size = gameObject.GetComponent<RectTransform>().sizeDelta;
        Debug.LogError(size);   
    }
}
