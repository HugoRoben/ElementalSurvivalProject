using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float currentZoom = 10f;
    public float pitch = 2f;
    public float sensitivity = 2.0f;
    float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10f, 20f);

        // Rotate the camera around the target horizontally
        target.Rotate(Vector3.up * mouseX);
    }

    void LateUpdate()
    {
        // Calculate the desired rotation around the target based on mouse input
        Quaternion rotation = Quaternion.Euler(xRotation, target.eulerAngles.y, 0f);

        // Apply the rotation to the camera's position
        transform.position = target.position - (rotation * offset * currentZoom);

        // Look at the target with an upward offset
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}