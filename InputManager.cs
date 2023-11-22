using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public MovePlayer movePlayer;
    public ShootBullet shootbullet;

    private int frameCountToDelay = 320;

    // public int EnemiesKilled = 0;

    void Update()
    {
        HandleMovementInput();

        if (Input.GetMouseButtonDown(0))
        {

            // ShootBullet shootingComponent = GetComponent<ShootBullet>();
            if (Input.GetMouseButtonDown(0))
            {
                // Schedule the DelayedShoot method to be called after the specified number of frames
                StartCoroutine(DelayedShoot());
                // if (shootingComponent != null)
                // {
                //     // Call the Shoot method
                //     shootingComponent.Shoot();
                // }
            }
            
        }
    }
    IEnumerator DelayedShoot()
    {
        // Wait for the specified number of frames
        for (int i = 0; i < frameCountToDelay; i++)
        {
            yield return null;
        }

        // yield return new WaitForSeconds(1);

        // After waiting, proceed to shoot
        ShootBullet shootingComponent = GetComponent<ShootBullet>();
        // Check if the component is not null
        if (shootingComponent != null)
        {
            // Call the Shoot method
            shootingComponent.Shoot();
        }
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movePlayer.HandleMovement(horizontalInput, verticalInput);
    }
}

