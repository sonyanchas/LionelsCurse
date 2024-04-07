using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The character's transform
    public Vector2 offset;   // Offset of the camera from the character
    [SerializeField] private float minX, maxX, minY, maxY; // Minimum and maximum bounds for X and Y axes

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + new Vector3(offset.x, offset.y, transform.position.z);

            // Clamp the camera position within the bounds
            float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);

            // Update the camera's position
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }

    // This method can be used to update the camera bounds if needed
    public void UpdateBounds(float newMinX, float newMaxX, float newMinY, float newMaxY)
    {
        minX = newMinX;
        maxX = newMaxX;
        minY = newMinY;
        maxY = newMaxY;
    }
}
