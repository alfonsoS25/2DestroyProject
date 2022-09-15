using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    public float Seconds;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Seconds);
    }
}
