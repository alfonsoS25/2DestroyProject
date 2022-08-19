using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject ExplosionParticle;

    [SerializeField]
    private Transform UiRoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetMouseButtonDown(0))
        {
            Explote();
        }
    }
    public void Explote()
    {
        Vector3 MisilePos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 MisileDir = Input.mousePosition - MisilePos;
        Vector3 ExplosionPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(ExplosionParticle, ExplosionPos, Quaternion.identity, UiRoot);

    }
}
