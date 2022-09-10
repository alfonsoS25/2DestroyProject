using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    CircleCollider2D circlecol;
    [SerializeField]
    private GameObject BlackHoleSprite;
    [SerializeField]
    private GameObject BlackHoleSpriteEnd;
    // Start is called before the first frame update
    void Start()
    {
        circlecol = gameObject.GetComponent<CircleCollider2D>();
        circlecol.usedByEffector = false;
        StartCoroutine(startStrengh());
    }

    IEnumerator startStrengh()
    {
        var clone = Instantiate(BlackHoleSprite, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.2f);
        circlecol.usedByEffector = true;
        transform.position = transform.position + new Vector3(0.01f,0,0);

        Destroy(clone, 0.8f);

        Destroy(this.gameObject, 1.4f);
        yield return new WaitForSeconds(0.8f);
        var clone2 = Instantiate(BlackHoleSpriteEnd, transform.position, Quaternion.identity);
        Destroy(clone2, 0.7f);

    }
}
