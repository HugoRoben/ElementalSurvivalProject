using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    // item interactions

    public MovePlayer movePlayer;
    public ShootBullet shootbullet;


    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movePlayer.HandleMovement(horizontalInput, verticalInput);
    }
}

