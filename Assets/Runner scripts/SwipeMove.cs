using UnityEngine; // Import Unity engine functionalities

public class SwipeMove : MonoBehaviour
{
    // Touch input start position
    private Vector2 startTouchPos; // Stores the touch position when a touch begins
    // Touch input end position
    private Vector2 endTouchPos;   // Stores the touch position when a touch ends

    // Minimum swipe distance to register a swipe (in pixels)
    [SerializeField] private int swipeThreshold = 50; // Threshold for detecting a swipe gesture

    // Y-axis positions for each lane: [0] = bottom, [1] = middle, [2] = top
    public float[] laneYPositions = new float[3] { -2f, 0f, 2f }; // Predefined Y positions for lanes

    // Speed of movement between lanes
    public float moveSpeed = 10f; // Controls how quickly the player moves between lanes

    // Current lane index
    private int currentLane = 1; // Index of the lane the player is currently in (start in middle)

    void Update() // Called once per frame
    {
        // --- Handle Touch Input ---
        if (Input.touchCount > 0) // Check if there is at least one touch on the screen
        {
            Touch MyTouch = Input.GetTouch(0); // Get the first touch

            if (MyTouch.phase == TouchPhase.Began) // When the touch starts
            {
                startTouchPos = MyTouch.position; // Record the starting position of the touch
            }
            else if (MyTouch.phase == TouchPhase.Ended) // When the touch ends
            {
                endTouchPos = MyTouch.position; // Record the ending position of the touch
                Vector2 delta = endTouchPos - startTouchPos; // Calculate the swipe vector

                // Check if the swipe is primarily vertical and above the threshold
                if (Mathf.Abs(delta.y) > swipeThreshold && Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
                {
                    if (delta.y > 0 && currentLane < laneYPositions.Length - 1) // Swipe up and not at top lane
                        currentLane++; // Move up a lane
                    else if (delta.y < 0 && currentLane > 0) // Swipe down and not at bottom lane
                        currentLane--; // Move down a lane
                }
            }
        }

        // --- Smooth Movement to Lane Y Position ---
        float targetY = laneYPositions[currentLane]; // Determine the target Y position based on current lane
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z); // Create a position vector for the target
        // Smoothly interpolate the player's position towards the target lane
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
}
