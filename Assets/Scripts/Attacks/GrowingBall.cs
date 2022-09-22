using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingBall : MonoBehaviour
{
    [SerializeField]
    private float increaseSizePerSecond;

    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x + (increaseSizePerSecond / 50),
            transform.localScale.x + (increaseSizePerSecond / 50)
            , transform.localScale.x + (increaseSizePerSecond / 50));
        rig.mass = rig.mass + (increaseSizePerSecond / 25);
    }
}
