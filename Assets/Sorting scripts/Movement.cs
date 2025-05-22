using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        // Check if there is any touch input
        if (Input.touchCount > 0)
        {
            Touch MyTouch = Input.GetTouch(0); // Get the first touch (index 0)

            /* Only move the box based on touch position on the X-axis.
               This converts the pixels space on the phone into the unity world (Unity Coordinates)
            Touch position = pixels. Box needs to move in World space. */
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(MyTouch.position);

            touchPosition.z = 0; // Ensure the Z position is always 0 (for 2D game)

            // Update the box's position on the X-axis based on the touch position
            transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);

        }
    }
}
