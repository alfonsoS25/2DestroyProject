using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLerp : MonoBehaviour
{/*
    Vector3 startPos;

    [SerializeField]
    private float offset;

    private float Velocity;

    [SerializeField]
    private float seconds;*/
    void Start()
    {
        //startPos = transform.position;
        //Velocity = offset / (50 * seconds);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(0, Mathf.PingPong(Time.time,3 ), 0);
        Debug.Log(Mathf.PingPong(Time.time, 3f));
        //if(transform.position.y > startPos.y + offset || transform.position.y < startPos.y)
        //{
        //    Velocity = -Velocity;
        //}
    }
}
