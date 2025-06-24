using UnityEngine; // Access Unity's core engine features

[AddComponentMenu("Gameplay/Boss Entry")] // Adds this script under the "Gameplay/Boss Entry" menu in the Component menu
public class BossEntry : MonoBehaviour // Handles sliding the boss into the scene on enable
{
    [Header("Entry Settings")] // Groups the following fields under an "Entry Settings" header in the inspector
    [Tooltip("Units per second the boss will slide in")] // Explains the entrySpeed field in the inspector
    [SerializeField] private float entrySpeed = 2f; // Speed at which the boss moves during entry

    [Tooltip("How many world units to move left when entering")] // Explains the entryDistance field in the inspector
    [SerializeField] private float entryDistance = 5f; // Distance the boss travels when entering

    private Vector3 targetPos; // World position where the boss should stop

    void OnEnable() // Called when the GameObject becomes active
    {
        // Calculate the final position by moving left by entryDistance
        targetPos = transform.position + Vector3.left * entryDistance;
        StartCoroutine(EnterScreen()); // Begin the entry animation coroutine
    }

    System.Collections.IEnumerator EnterScreen() // Coroutine to slide the boss in
    {
        // Continue moving until close enough to the target position
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            // Move towards the target position at entrySpeed units per second
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                entrySpeed * Time.deltaTime
            );
            yield return null; // Wait until the next frame
        }
    }
}
