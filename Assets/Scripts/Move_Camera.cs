using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Camera : MonoBehaviour
{
    float xRot;
    float yRot;
    float xRotCurrent;
    float yRotCurrent;
    [SerializeField] private Camera player;
    [SerializeField] private GameObject playerGameObj;
    [SerializeField] float sensivity = 5f;
    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] float currentVelocityX;
    [SerializeField] float currentVelocityY;

    private void Update()
    {
        MouseMove();
    }
    void MouseMove()
    {
        xRot += Input.GetAxis("Mouse X") * sensivity;
        yRot += Input.GetAxis("Mouse Y") * sensivity;
        yRot = Mathf.Clamp(yRot, -90, 90);
        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelocityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelocityY, smoothTime);

        player.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
        playerGameObj.transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);
    }
}
