using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField]
    private LayerMask Block;

    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    private float pushforce = 4f;
    bool IsDrag = false;

    Vector2 StartPoint;
    Vector2 EndPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    Camera cam;

    public DotsGenerator DotsGen;

    private bool isShooted = false;


    void Start()
    {
        DotsGen = GameObject.FindGameObjectWithTag("DotMan").gameObject.GetComponent<DotsGenerator>();
        cam = Camera.main;
        OnDragStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooted)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            OnDragStart();
        }
        if(Input.GetMouseButtonUp(0))
        {
            OnDragEnd();
        }
        if(IsDrag)
        {
            OnDrag();
        }
    }

    void OnDragStart()
    {
        if(isShooted)
        {
            return;
        }
        gameObject.GetComponent<Rigidbody2D>().Sleep();
        StartPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        IsDrag = true;
        DotsGen.Show();
    }

    private void OnDrag()
    {
        EndPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(StartPoint, EndPoint);
        direction = (StartPoint - EndPoint).normalized;
        force = direction *  distance * pushforce;
        Debug.DrawRay(StartPoint, EndPoint);
        DotsGen.updateDots(transform.position, force);
    }

    void OnDragEnd()
    {
        isShooted = true;
        gameObject.GetComponent<Rigidbody2D>().WakeUp();
        IsDrag = false;
        gameObject.GetComponent<Rigidbody2D>().AddForce(force*50);
        //DotsGen.Hide();
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = -40;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {

        }
    }

}
