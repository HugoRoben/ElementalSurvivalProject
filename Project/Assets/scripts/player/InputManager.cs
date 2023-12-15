using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public MovePlayer movePlayer;
    public float sprintSpeedAdd = 3;
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown("left shift")) movePlayer.movementSpeed += sprintSpeedAdd;
            if (Input.GetKeyUp("left shift")) movePlayer.movementSpeed -= sprintSpeedAdd;
        }
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movePlayer.HandleMovement(horizontalInput, verticalInput);
    }
}

