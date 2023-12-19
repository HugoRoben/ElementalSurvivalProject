using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public MovePlayer movePlayer;
    public MoveCamera moveCamera;
    
    public float sprintSpeedAdd = 3;
    // camera settings
    public float sensitivity = 2.0f;
    float mouseZoom; float mouseX; float mouseY; float xRotation;
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown("left shift")) movePlayer.movementSpeed += sprintSpeedAdd;
            if (Input.GetKeyUp("left shift")) movePlayer.movementSpeed -= sprintSpeedAdd;
            mouseZoom = -Input.GetAxis("Mouse ScrollWheel");
            mouseX = Input.GetAxis("Mouse X") * sensitivity;
            mouseY = Input.GetAxis("Mouse Y") * sensitivity;
            xRotation = -mouseY;
            xRotation = Mathf.Clamp(xRotation, -10f, 20f);
            moveCamera.HandleCamera(xRotation, mouseZoom, mouseX);
        }
        HandleMovementInput();
    }

    void LateUpdate()
    {
        if (!PauseMenu.isPaused) moveCamera.HandleCameraRotation(xRotation, mouseZoom);
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movePlayer.HandleMovement(horizontalInput, verticalInput);
    }
}

