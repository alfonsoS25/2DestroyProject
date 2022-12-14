using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    Rigidbody2D rig;

    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    private float Speed;

    Vector3 target;

    [SerializeField]
    private LayerMask layer;

    private CameraScript _cameraScript;
    void Start()
    {
        _cameraScript = Camera.main.gameObject.GetComponent<CameraScript>();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        target = worldPosition-transform.position;
        target.z = 0;

        Debug.DrawRay(transform.position, target);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target, Mathf.Infinity, layer);

        if (hit)
        {
            _cameraScript.startCameraShake(1.4f);
            var clone = Instantiate(Explosion, hit.transform.position, Quaternion.identity);
            Destroy(clone, 0.1f);
        }
        else
        {
            Debug.Log(";o");
        }


    }
    private void Update()
    {
       
    }
}
