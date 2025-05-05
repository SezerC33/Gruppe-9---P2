using UnityEngine;

public class ClickToMove2D : MonoBehaviour
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