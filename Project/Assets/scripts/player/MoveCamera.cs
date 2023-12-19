// script to manage the movement of the camera in-game

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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void HandleCamera(float xRotation, float mouseZoom, float mouseX)
    {
        target.Rotate(Vector3.up * mouseX);
    }
    public void HandleCameraRotation(float xRotation, float mouseZoom)
    {
        currentZoom = mouseZoom * zoomSpeed;  
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        // Calculate the desired rotation around the target based on mouse input
        Quaternion rotation = Quaternion.Euler(xRotation, target.eulerAngles.y, 0f);

        // Apply the rotation to the camera's position
        transform.position = target.position - (rotation * offset * currentZoom);

        // Look at the target with an upward offset
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}

