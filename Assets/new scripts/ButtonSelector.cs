using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject ExplosionParticle;
    [SerializeField]
    private GameObject ExplosionParticleButton;

    [SerializeField]
    private Transform UiRoot;


    [SerializeField]
    private GameObject ExplosionHolder;
    // Start is called before the first frame update
    void Start()
    {
        ExplosionHolder = Instantiate(ExplosionParticleButton, UiRoot);
        ExplosionHolder.SetActive(false);

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
    IEnumerator setOff()
    {
        yield return new WaitForSeconds(1);
        ExplosionHolder.SetActive(false);
    }
    public void Explote()
    {
        ExplosionHolder.SetActive(true);
        Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 InputPos = Input.mousePosition - Pos;
        Vector3 ExplosionPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ExplosionHolder.transform.position = ExplosionPos;
        // Instantiate(ExplosionParticleButton, ExplosionPos, Quaternion.identity, UiRoot);
        StartCoroutine(setOff());
    }

    

    public void ExploteTouch()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 TouchPos = Camera.main.ScreenToWorldPoint(touch.position);
        Instantiate(ExplosionParticle, TouchPos, Quaternion.identity, UiRoot);
    }
}
