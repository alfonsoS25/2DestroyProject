using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layer;

    [SerializeField]
    private CameraScript _cameraScript;
    void Start()
    {
        _cameraScript = Camera.main.gameObject.GetComponent<CameraScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == _layer)
        {
            _cameraScript.startCameraShake();
        }
    }
}
