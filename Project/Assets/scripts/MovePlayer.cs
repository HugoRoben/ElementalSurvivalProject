using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform cameraTransform;

    public void HandleMovement(float horizontalInput, float verticalInput)
    {
        // Get the forward direction of the camera without the vertical component
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        // Calculate movement vector based on the camera direction
        Vector3 movement = (cameraForward * verticalInput + cameraTransform.right * horizontalInput) * movementSpeed * Time.deltaTime;

        // Apply the movement
        transform.Translate(movement, Space.World);
    }
}
