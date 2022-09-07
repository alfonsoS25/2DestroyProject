using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikePlanes : MonoBehaviour
{
    [SerializeField] private Vector3 dropPos;

    [SerializeField] private bool hasDropped = false;

    [SerializeField] private GameObject Bomb;
    void Start()
    {
        transform.position = new Vector3(-20, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0.1f, 0, 0);
        float Place = Vector2.Distance(transform.position, dropPos);
        if(Place < 1)
        {
            if (!hasDropped)
            {
                Instantiate(Bomb, transform.position, Quaternion.identity);
                hasDropped = true;
            }
            Debug.Log("estoy");
        }
    }
}
