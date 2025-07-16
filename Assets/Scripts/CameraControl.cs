using UnityEngine;

public class CameraHorizontalMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Movement speed
    [SerializeField] private float minX = -10f; // Left boundary
    [SerializeField] private float maxX = 10f; // Right boundary

    void Update()
    {
        // Get horizontal input (A/D or LeftArrow/RightArrow by default)
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Calculate movement
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        
        // Apply movement
        transform.Translate(movement);
        
        // Clamp position to boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }
}