using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject ExplosionParticle;
    [SerializeField]
    private GameObject ExplosionParticleButton;

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
        if (Input.touchCount > 0)
        {
            ExploteTouch();
        }
    }
    public void Explote()
    {
        Vector3 MisilePos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 MisileDir = Input.mousePosition - MisilePos;
        Vector3 ExplosionPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(ExplosionParticle, ExplosionPos, Quaternion.identity, UiRoot);
        Instantiate(ExplosionParticleButton, ExplosionPos, Quaternion.identity, UiRoot);
    }

    public void ExploteTouch()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 TouchPos = Camera.main.ScreenToWorldPoint(touch.position);
        Instantiate(ExplosionParticle, TouchPos, Quaternion.identity, UiRoot);
    }
}
