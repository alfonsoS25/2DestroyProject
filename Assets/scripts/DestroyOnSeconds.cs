using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyOnSeconds : MonoBehaviour
{
    [SerializeField]
    public float Seconds;


    [SerializeField]
    private GameObject Camerapos;

    [SerializeField]
    private float OffsetX;
    [SerializeField]
    private float OffsetY;

    private float timer = 0;
    void Start()
    {
        Camerapos = Camera.main.gameObject;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            destroynow();
        }
        if (transform.position.x < Camerapos.transform.position.x - OffsetX)
        {
            destroynow();
        }
        if (transform.position.x > Camerapos.transform.position.x + OffsetX)
        {
            destroynow();
        }
        if (transform.position.y < Camerapos.transform.position.y - OffsetY)
        {
            destroynow();
        }
        if (transform.position.y > Camerapos.transform.position.y + OffsetY)
        {
            destroynow();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DemolitionBall") && gameObject.transform.position.y > collision.gameObject.transform.position.y)
        {
           gameObject.SetActive(false);
        }
    }

        void destroynow()
    {
        timer = 0;
        this.gameObject.SetActive(false);
    }

}
