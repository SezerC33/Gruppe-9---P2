using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // The Transform of the object the camera will follow

    void LateUpdate()
    {
        if (target != null) // Only proceed if a target has been assigned
        {
            Vector3 newPos = target.position; // Copy the target's current position
            newPos.z = -10f;              // Adjust Z so the camera stays at the correct distance
            transform.position = newPos;  // Update the camera's position to follow the target
        } // If there's no target, the camera stays where it is
    }
}
