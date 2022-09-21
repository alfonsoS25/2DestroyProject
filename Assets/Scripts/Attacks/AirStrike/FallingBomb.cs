using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBomb : MonoBehaviour
{
    [SerializeField]
    private LayerMask Block;

    [SerializeField]
    private GameObject Explosion;

    private bool IsGoingToExplode = false;

    private CameraScript _cameraScript;

    private void Start()
    {
        _cameraScript = Camera.main.gameObject.GetComponent<CameraScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            if (!IsGoingToExplode)
            {
                Explode();
                IsGoingToExplode = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("aweno"))
        {
            if (!IsGoingToExplode)
            {
                Explode();
                IsGoingToExplode = true;
            }
        }
    }

    private void Explode()
    {
        _cameraScript.startCameraShake();
        var BombClone = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(BombClone, 0.1f);
    }
}
