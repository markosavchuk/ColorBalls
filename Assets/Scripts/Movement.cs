using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float MouseRorationSpeed = 3.5f;
    private const float KeyboardRorationSpeed = 0.5f;
    private const float ZoomSpeed = 5f;
    private const float MinZOffset = -8f;
    private const float MaxZOffset = -90f;

    public GameObject MainBall;
    public Camera Camera;

    public float BallSpeed;

    public float CameraXOffset;
    public float CameraYOffset;
    public float CameraZOffset;

    public float HorizontalAngle;

    private void Update()
    {        
        HandleCameraMovement(Camera, MainBall);
    }

    private void FixedUpdate()
    {
        HandleBallMovement(MainBall);
    }

    private void HandleBallMovement(GameObject ball)
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        HorizontalAngle += movementHorizontal * KeyboardRorationSpeed;

        var vector = new Vector3(movementHorizontal, 0, movementVertical);
        var movement = Quaternion.Euler(0, HorizontalAngle, 0) * vector;

        ball.GetComponent<Rigidbody>().AddForce(movement * BallSpeed * Time.deltaTime);        
    }

    private void HandleCameraMovement(Camera camera, GameObject mainBall)
    {
        if (Input.GetMouseButton(0))
        {
            HorizontalAngle += Input.GetAxis("Mouse X") * MouseRorationSpeed;
        }

        CameraZOffset += Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;

        if (Math.Abs(CameraZOffset) < Math.Abs(MinZOffset))
        {
            CameraZOffset = MinZOffset;
        }
        else if (Math.Abs(CameraZOffset) > Math.Abs(MaxZOffset))
        {
            CameraZOffset = MaxZOffset;
        }

        camera.transform.position = mainBall.transform.position;
        Camera.transform.rotation = Quaternion.Euler(-CameraZOffset, HorizontalAngle, 0);
        Camera.transform.Translate(new Vector3(CameraXOffset, CameraYOffset, CameraZOffset));
    }
}
