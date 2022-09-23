using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private Vector3 hola2;
    private Vector3 hola;

    [SerializeField]
    private LayerMask layer;

    private SliderJoint2D sliderjoint;

    [SerializeField]
    private GameObject equisde;

    public JointMotor2D troleomaximo;
    // Start is called before the first frame update
    void Start()
    {
        
        sliderjoint = gameObject.GetComponent<SliderJoint2D>();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        hola2 = worldPosition - transform.position;
        hola2.z = 0;
        hola = transform.position;
        Debug.DrawRay(hola, hola2);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, hola2, Mathf.Infinity,layer);

        if(hit)
        {
            JointMotor2D motorero = new JointMotor2D { motorSpeed = 20, maxMotorTorque = 100 };

            equisde = hit.collider.gameObject;
            var troleo = equisde.AddComponent<SliderJoint2D>();
            troleo.connectedBody = this.gameObject.GetComponent<Rigidbody2D>();
            troleo.motor = motorero;
            troleo.enableCollision = true;
            troleo.useLimits = true;


            //troleisimo.motor.motorSpeed = new JointMotor2D().motorSpeed;
            //troleo.motor.motorSpeed = ;
            //sliderjoint.connectedBody = equisde.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
