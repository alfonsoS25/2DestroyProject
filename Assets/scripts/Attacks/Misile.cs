using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misile : MonoBehaviour
{
    Rigidbody2D rig;

    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    private float Speed;
    void Start()
    {
        Vector3 MisilePos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 MisileDir = Input.mousePosition - MisilePos;
        float MisileDngle = Mathf.Atan2(MisileDir.y, MisileDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(MisileDngle, Vector3.forward);
        rig = GetComponent<Rigidbody2D>();
           rig.velocity = transform.right * Speed;

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("SmallBlock"))
        {
            Debug.Log("Hit");
            var Clone =Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(Clone, 0.1f);
            Destroy(this.gameObject);
        }
    }

}
