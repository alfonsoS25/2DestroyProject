using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLerp : MonoBehaviour
{
    [SerializeField]
    private float xoffset=0;
    [SerializeField]
    private float yoffset=0;

    [SerializeField]
    private AnimationCurve curve;

    private void FixedUpdate()
    {
        float timeValue = curve.Evaluate((Mathf.PingPong(Time.time + yoffset,1)));
        transform.position = new Vector3(xoffset, Mathf.PingPong(timeValue, 3), 0);
        Debug.Log(timeValue);
    }
}
