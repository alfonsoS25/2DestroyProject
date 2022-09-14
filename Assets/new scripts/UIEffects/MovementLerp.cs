using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLerp : MonoBehaviour
{
    Vector3 startPos;

    [SerializeField]
    private float offset;

    private float Velocity;

    [SerializeField]
    private float seconds;
    void Start()
    {
        startPos = transform.position;
        Velocity = offset / (50 * seconds);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log(transform.position);
        transform.Translate(new Vector3(0, Velocity, 0));
        if(transform.position.y > startPos.y + offset || transform.position.y < startPos.y)
        {
            Velocity = -Velocity;
        }
    }
}
