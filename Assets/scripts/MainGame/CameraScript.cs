using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float startCameraSize;

    [SerializeField] private Camera thisCamera;

    [SerializeField] private Vector3 playerPos;

    [SerializeField] Vector3 startPos;

    [Space(10)]   [Header("PlayerFocus")]   [Space(10)]

    [SerializeField]
    private float PlayerCamOffset;

    [SerializeField]
    private float PlayerCamSize;

    [SerializeField]
    private float PlayerCamSpeed;
    [SerializeField]
    private float PlayerCamSpeedTime;

    [SerializeField]
    private Vector3 PlayerCamSpeedMovement = Vector3.zero;
    enum cameraState
    {
        Ilde,
        Centered,
        PlayerFocus,
        LevelFocus,
    }

    [SerializeField]
    private cameraState camState;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startCameraSize = thisCamera.orthographicSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(camState)
        {
            case cameraState.Ilde:
                CameraIlde();
                break;
            case cameraState.Centered:
                break;
            case cameraState.LevelFocus:
                break;
            case cameraState.PlayerFocus:
                playerFocus();
                break;
        }
    }

    private void playerFocus()
    {
        Vector3 Pos = new Vector3(playerPos.x + PlayerCamOffset, playerPos.y, -10);
        cameraLookAt(Pos,PlayerCamSize);
    }

    private void CameraIlde()
    {
        cameraLookAt(startPos,startCameraSize);
    }

    private void cameraLookAt(Vector3 target, float cameraSize)
    {
        if (transform.position == target)
        {
            return;
        }
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            //transform.position = position;
            return;
        }
        transform.position = Vector3.SmoothDamp(transform.position, target, ref PlayerCamSpeedMovement, PlayerCamSpeedTime);
        float actualCamSize = thisCamera.orthographicSize;
        float RefCameraSizeSpeed = 0;
        float camSize = Mathf.SmoothDamp(actualCamSize, cameraSize, ref RefCameraSizeSpeed, PlayerCamSpeedTime / 10);
        thisCamera.orthographicSize = camSize;
    }
}

