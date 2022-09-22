using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private Vector3 hola;
    private Vector3 hola2;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 TouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 pos = Camera.main.ScreenToWorldPoint(TouchPos);
        Vector3 dir = Camera.main.ScreenToWorldPoint(TouchPos) - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        hola = transform.position;
        RaycastHit2D ray = Physics2D.Raycast(transform.position,transform.forward,Mathf.Infinity);
        if (ray)
        {
            Debug.Log(ray.collider.name);
            hola2 = ray.collider.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hola);
        Debug.Log(hola2);
        Debug.DrawRay(hola, transform.forward*10);
    }
}
