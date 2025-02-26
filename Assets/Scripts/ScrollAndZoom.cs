using UnityEngine;
using UnityEngine.SocialPlatforms;

// Purpose: This class allows you to rotate the object (Organ) and allows you to zoom into it
public class ScrollAndZoom
{
    public Camera cameraToControl;
    public Transform targetObject;  // Reference to the object to rotate around
    public float rotationSpeed = 100f;  // Speed of rotation
    public float moveSpeed = 10f;  // Speed of movement
    public float zoomSpeed = 10f;
    public float minZoom = 5f;
    public float maxZoom = 60f;

    private Vector3 lastMousePosition;

    void Update()
    {
        // Handle camera zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            cameraToControl.fieldOfView = Mathf.Clamp(cameraToControl.fieldOfView - scroll * zoomSpeed, minZoom, maxZoom);
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

            float angleX = -deltaMousePosition.y * rotationSpeed * Time.deltaTime;
            float angleY = deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            cameraToControl.transform.RotateAround(targetObject.position, cameraToControl.transform.right, angleX);
            cameraToControl.transform.RotateAround(targetObject.position, Vector3.up, angleY);

            lastMousePosition = Input.mousePosition;
        }

        // Handle camera movement
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

            Vector3 move = new Vector3(-deltaMousePosition.x * moveSpeed * Time.deltaTime, -deltaMousePosition.y * moveSpeed * Time.deltaTime, 0);
            cameraToControl.transform.Translate(move, Space.Self);

            lastMousePosition = Input.mousePosition;
        }
    }
}
