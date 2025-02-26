using UnityEngine;

// Purpose: Allows rotation, movement, and zooming of an object (Organ)
public class ScrollAndZoom : MonoBehaviour
{
    public Transform targetObject;  // The object to manipulate
    public float rotationSpeed = 100f;  // Speed of rotation
    public float moveSpeed = 0.1f;  // Speed of movement
    public float zoomSpeed = 0.1f;  // Speed of zooming
    public float minScale = 0.5f;  // Minimum scale limit
    public float maxScale = 3f;    // Maximum scale limit

    private Vector3 lastMousePosition;

    void Update()
    {
        // Handle object zoom (Scaling)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            float scaleChange = scroll * zoomSpeed;
            Vector3 newScale = targetObject.localScale + Vector3.one * scaleChange;
            targetObject.localScale = Vector3.Max(Vector3.one * minScale, Vector3.Min(Vector3.one * maxScale, newScale));
        }

        // Handle object rotation (Left Click & Drag)
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

            float angleX = -deltaMousePosition.y * rotationSpeed * Time.deltaTime;
            float angleY = deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            targetObject.Rotate(Vector3.right, angleX, Space.World);
            targetObject.Rotate(Vector3.up, angleY, Space.World);

            lastMousePosition = Input.mousePosition;
        }

        // Handle object movement (Right Click & Drag)
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(deltaMousePosition.x * moveSpeed, deltaMousePosition.y * moveSpeed, 0);
            targetObject.position += move;

            lastMousePosition = Input.mousePosition;
        }
    }
}
