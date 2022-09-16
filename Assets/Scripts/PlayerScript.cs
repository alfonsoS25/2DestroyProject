using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Char;
    // Start is called before the first frame update
    [SerializeField]    private GameObject Misile;
    [SerializeField]    private GameObject BlackHole;
    [SerializeField]    private GameObject Laser;
    [SerializeField]    private GameObject wrekingBall;
    [SerializeField]    private GameObject Grenade;
    [SerializeField]    private GameObject AirStrike;
    [SerializeField]    private GameObject satelitalStrike;
    [SerializeField]    private GameObject drill;
    [SerializeField]    private GameObject tnt;
    [SerializeField]    private GameManager gameManager;

    [SerializeField]
    private int Power;

    private float delay=0.4f;

    [SerializeField]
    private GameObject[] uiButtons;

    // Update is called once per frame
    private bool CheckDistance(Vector3 pressed)
    {
        bool isNear = false;
        for (int i = 0; i < uiButtons.Length; i++) {
            Vector3 buttonpos = uiButtons[i].transform.position;
            buttonpos.z = 0;

            float dist1 = Vector3.Distance(pressed, buttonpos);
            

            if(dist1< 3f)
            {
                isNear = true;
                break;
            }
            else
            {

            }
        }
        return isNear;
    }
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

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.z = 0;

        if (CheckDistance(worldPosition))
        {
            return;
        }

        if (gameManager.gamestate != GameManager.gameState.Ilde)
        {
            return;
        }
        gameManager.gamestate = GameManager.gameState.Attacking;

        switch (Power)
        {
            case 0:
                //var GrenadeClone = Instantiate(Grenade, transform.position, transform.rotation);
                var GrenadeClone = Instantiate(Misile, transform.position, transform.rotation);
                //Vector3 MisilePos = Camera.main.WorldToScreenPoint(transform.position);
                //Vector3 MisileDir = Input.mousePosition - MisilePos;

                //Debug.Log(MisileDir);
                //float MisileDngle = Mathf.Atan2(MisileDir.y, MisileDir.x) * Mathf.Rad2Deg;
                //GrenadeClone.transform.rotation = Quaternion.AngleAxis(MisileDngle, Vector3.forward);
                //GrenadeClone.GetComponent<Rigidbody2D>().velocity = (MisileDir/20);

                //generate a misile

                /*
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
                 break;
            case 3:
                var wrekingBallClone = Instantiate(wrekingBall, worldPosition, transform.rotation);
                Destroy(wrekingBallClone, 4f); break;
            case 4:
                var airStrikeClone = Instantiate(AirStrike, transform.position, transform.rotation);
                break;
            case 5:
                var grenadeClne = Instantiate(Grenade, transform.position, transform.rotation);
                break;
            case 6:
                var SatelitalStrike = Instantiate(Grenade, transform.position, transform.rotation);
                break;
        }
    }
    void AttackTouch()
    {
        delay = 0;
        if (delay > 0.4f)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 TouchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (CheckDistance(TouchPos))
            {
                return;
            }
            if (gameManager.gamestate != GameManager.gameState.Ilde)
            {
                return;
            }
            gameManager.gamestate = GameManager.gameState.Attacking;
            TouchPos.z = 0f;
            switch (Power)
            {
                case 0:
                    var BombClone = Instantiate(Misile, TouchPos, transform.rotation);
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
                case 4:
                    var airStrikeClone = Instantiate(AirStrike, TouchPos, transform.rotation);
                    break;
                case 5:
                    var grenadeClne = Instantiate(Grenade, TouchPos, transform.rotation);
                    break;
            }
        }
    }

    public void ChooceWeapon()
    {
        if (gameManager.gamestate == GameManager.gameState.Ilde || gameManager.gamestate == GameManager.gameState.Attacking)
        {
            gameManager.gamestate = GameManager.gameState.SelectingWeapon;
        }
        else
        {
            gameManager.gamestate = GameManager.gameState.Ilde;
        }

    }

}
