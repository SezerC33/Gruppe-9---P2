using UnityEngine;

// Attach this script to the player GameObject in a 2D side-scrolling runner game
public class SwipeMove : MonoBehaviour
{
    // Touch input positions
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    // Minimum swipe distance to register a swipe (in pixels)
    [SerializeField] private int swipeThreshold = 50;

    // Y-axis positions for each lane: [0] = bottom, [1] = middle, [2] = top
    public float[] laneYPositions = new float[3] { -2f, 0f, 2f };

    // Speed of movement between lanes
    public float moveSpeed = 10f;

    // Current lane index
    private int currentLane = 1;

    void Update()
    {
        // --- Handle Touch Input ---
        if (Input.touchCount > 0)
        {
            Touch MyTouch = Input.GetTouch(0);

            if (MyTouch.phase == TouchPhase.Began)
            {
                startTouchPos = MyTouch.position;
            }
            else if (MyTouch.phase == TouchPhase.Ended)
            {
                endTouchPos = MyTouch.position;
                Vector2 delta = endTouchPos - startTouchPos;

                if (Mathf.Abs(delta.y) > swipeThreshold && Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
                {
                    if (delta.y > 0 && currentLane < laneYPositions.Length - 1)
                        currentLane++;
                    else if (delta.y < 0 && currentLane > 0)
                        currentLane--;
                }
            }
        }

        // --- Smooth Movement to Lane Y Position ---
        float targetY = laneYPositions[currentLane];
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
}
