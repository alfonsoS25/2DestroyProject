using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Bomb;
    [SerializeField]
    private GameObject BlackHole;

    [SerializeField]
    private GameObject Char;
    [SerializeField]
    private GameObject Laser;
    [SerializeField]
    private GameObject wrekingBall;

    [SerializeField]
    private GameObject Grenade;

    [SerializeField]
    private int Power;
    [SerializeField]
    private GameManager gameManager;

    private float delay=0.4f;



    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            AttackTouch();   
        }

        if(Input.GetMouseButtonDown(0))
        {
            attackMouse();   
        }
        if (delay <= 0.4f)
        {
            delay += Time.deltaTime;
        }
    }
    public void ChangePower(int power)
    {
        Power = power;
    }

    void attackMouse()
    {
        if(gameManager.gamestate != GameManager.gameState.Ilde)
        {
            return;
        }
        gameManager.gamestate = GameManager.gameState.Attacking;


        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.z = 0;


        switch (Power)
        {
            case 0:
                var GrenadeClone = Instantiate(Grenade, transform.position, transform.rotation);
                //Vector3 MisilePos = Camera.main.WorldToScreenPoint(transform.position);
                //Vector3 MisileDir = Input.mousePosition - MisilePos;

               // Debug.Log(MisileDir);
               // float MisileDngle = Mathf.Atan2(MisileDir.y, MisileDir.x) * Mathf.Rad2Deg;
               // GrenadeClone.transform.rotation = Quaternion.AngleAxis(MisileDngle, Vector3.forward);
                //GrenadeClone.GetComponent<Rigidbody2D>().velocity = (MisileDir/20);

                /*generate a misile
                var MisileClone = Instantiate(Bomb, transform.position, transform.rotation);
                Vector3 MisilePos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 MisileDir = Input.mousePosition - MisilePos;
                float MisileDngle = Mathf.Atan2(MisileDir.y, MisileDir.x) * Mathf.Rad2Deg;
                MisileClone.transform.rotation = Quaternion.AngleAxis(MisileDngle, Vector3.forward);*/

                break;
            case 1:
                var DestroyerLaser = Instantiate(Laser, transform.position, transform.rotation);
                //DestroyerLaser.transform.position = new Vector3(transform.position.x + (transform.localScale.x / 2), transform.position.y, transform.position.z);

                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                DestroyerLaser.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                break;
            case 2:
                var BlackholeClone = Instantiate(BlackHole, worldPosition, transform.rotation);
                Destroy(BlackholeClone, 0.4f); break;
            case 3:
                var wrekingBallClone = Instantiate(wrekingBall, worldPosition, transform.rotation);
                Destroy(wrekingBallClone, 4f); break;
        }
    }
    void AttackTouch()
    {
        delay = 0;
        if (delay > 0.4f)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 TouchPos = Camera.main.ScreenToWorldPoint(touch.position);
            TouchPos.z = 0f;
            switch (Power)
            {
                case 0:
                    var BombClone = Instantiate(Bomb, TouchPos, transform.rotation);
                    Destroy(BombClone, 0.1f); break;
                case 1:

                    var DestroyerLaser = Instantiate(Laser, transform.position, transform.rotation);
                    //DestroyerLaser.transform.position = new Vector3(transform.position.x + (transform.localScale.x / 2), transform.position.y, transform.position.z);

                    Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 dir = Camera.main.ScreenToWorldPoint(touch.position) - pos;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    DestroyerLaser.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    break;
                case 2:
                    var BlackholeClone = Instantiate(BlackHole, TouchPos, transform.rotation);
                    Destroy(BlackholeClone, 0.4f); break;
                case 3:
                    var wrekingBallClone = Instantiate(wrekingBall, TouchPos, transform.rotation);
                    Destroy(wrekingBallClone, 4f); break;
            }
        }
    }

}
