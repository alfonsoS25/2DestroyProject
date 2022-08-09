using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private LayerMask Block;

    [SerializeField]
    private GameObject Explosion;

    private bool IsGoingToExplode = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (!IsGoingToExplode)
            {
                StartCoroutine(Explode());
                IsGoingToExplode = true;
            }
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(3);
        var BombClone = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(BombClone, 0.1f);
    }
}
