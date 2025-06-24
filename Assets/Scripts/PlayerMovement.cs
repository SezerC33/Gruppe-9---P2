using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Movement speed adjustable in the inspector

    private Vector3 destination; // World-space position the player is moving toward
    private bool hasDestination = false; // Whether a destination has been set
    private Rigidbody2D rb; // Reference to the Rigidbody2D component for physics-based movement

    void Start() // Called before the first frame update
    {
        rb = GetComponent<Rigidbody2D>(); // Cache the Rigidbody2D component
    }

    void Update() // Called once per frame
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // On mobile touch begin
        {
            SetDestination(Input.GetTouch(0).position); // Set movement target to touch position
        }

        if (Input.GetMouseButtonDown(0)) // On left mouse button click
        {
            SetDestination(Input.mousePosition); // Set movement target to mouse position
        }
    }

    void FixedUpdate() // Called at fixed intervals for physics updates
    {
        if (hasDestination) // Only move if a destination is set
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, destination, moveSpeed * Time.fixedDeltaTime); // Calculate step toward destination
            rb.MovePosition(newPos); // Move the Rigidbody2D to the new position

            if (Vector2.Distance(rb.position, destination) < 0.1f) // If close enough to destination
            {
                hasDestination = false; // Stop moving
            }
        }
    }

    private void SetDestination(Vector2 screenPosition) // Converts screen input to world position
    {
        destination = Camera.main.ScreenToWorldPoint(screenPosition); // Translate screen coords to world coords
        destination.z = 0f; // Ensure movement stays in 2D plane
        hasDestination = true; // Flag to start moving
    }
}



/*
{
    [SerializeField] private Transform character; // The character you want to move
    [SerializeField] private float moveSpeed = 5f; // How fast the character moves

    private Vector3 destination; // Where the character should go
    private bool hasDestination = false; // Whether the character should move

    void Update()
    {
        // Detect a touch on mobile (From ChatGPT)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position; // Get the touch position
            SetDestination(touchPosition); // Now call SetDestination with it
        }

        // Detect a mouse click for testing in the editor
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition; // Get the mouse position
            SetDestination(mousePosition); // Call SetDestination with it
        }

        // Move the character if we have a destination
        if (hasDestination)
        {
            MoveCharacter(); // Call the movement function
        }
    }

    // Define the SetDestination method properly
    private void SetDestination(Vector2 screenPosition)
    {
        // Convert screen position to world position
        destination = Camera.main.ScreenToWorldPoint(screenPosition);
        destination.z = 0f; // Keep character on the same Z layer (important for 2D)
        hasDestination = true; // Start moving
    }

    private void MoveCharacter()
    {
        // Move character toward destination
        character.position = Vector3.MoveTowards(character.position, destination, moveSpeed * Time.deltaTime);

        // If close enough to the destination, stop moving
        if (Vector3.Distance(character.position, destination) < 0.1f)
        {
            hasDestination = false;
        }
    }
}
*/