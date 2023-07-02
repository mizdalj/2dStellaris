using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float baseMovementSpeed = 30f; // This will control the base speed of the camera movement
    public float zoomSpeed = 10f;
    public float minSize = 3f;
    public float maxSize = 128f;
    public float damping = 0.03f; // This will control how smooth the camera movement is

    private Vector3 velocity = Vector3.zero; // This will store the velocity of the camera

    void Update()
    {
        // Calculate the actual movement speed based on the camera's zoom level
        float movementSpeed = baseMovementSpeed * Camera.main.orthographicSize;

        // Hold the middle mouse button to move the camera
        if (Input.GetMouseButton(2))
        {
            float h = movementSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
            float v = movementSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

            Vector3 targetPosition = transform.position + new Vector3(-h, -v, 0);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
        }

        // Use ZQSD or WASD keys to move the camera
        float moveHorizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        Vector3 targetPositionKeys = transform.position + new Vector3(moveHorizontal / 2, moveVertical / 2, 0);
        transform.position = Vector3.SmoothDamp(transform.position, targetPositionKeys, ref velocity, damping);

        // Zoom with the mouse scroll wheel
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float newSize = Camera.main.orthographicSize - zoomAmount;
        Camera.main.orthographicSize = Mathf.Clamp(newSize, minSize, maxSize);
    }
}