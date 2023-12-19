using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float laserWidth = 0.1f; // Width of the laser beam
    public float laserMaxLength = 50f; // Maximum length of the laser beam

    private LineRenderer lineRenderer;

    void Start()
    {
        // Get the Line Renderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Set initial properties of the Line Renderer
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        // Update the laser beam position and direction
        Vector3 startPoint = transform.position;
        Vector3 endPointUp = transform.position + transform.up * laserMaxLength;
        Vector3 endPointDown = transform.position - transform.up * 10;

        // Set the laser beam positions
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPointUp);
        lineRenderer.SetPosition(2, endPointDown);
    }
}
