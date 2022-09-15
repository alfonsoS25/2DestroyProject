using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikePlanes : MonoBehaviour
{
    public float dropPos;

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
        float Place = transform.position.x - dropPos;
        if(Place > 0)
        {
            if (!hasDropped)
            {
                var bomb = Instantiate(Bomb, transform.position, Quaternion.identity);
                bomb.GetComponent<Rigidbody2D>().isKinematic = false;
                hasDropped = true;
            }
            Debug.Log("estoy");
        }
    }
}
