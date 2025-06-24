using UnityEngine; // Access Unity's core engine features

public class PlayerCollector : MonoBehaviour // Handles player pickups and triggers boss spawn
{
    private int CorrectPickupCount; // Tracks how many correct pickups have occurred

    public GameObject bossPrefab; // Assign the boss prefab to spawn after pickups

    void OnTriggerEnter2D(Collider2D other) // Called when another collider enters this trigger
    {
        if (!other.CompareTag("Player")) // Ignore collisions not tagged as Player
            return;

        Destroy(other.gameObject); // Remove the player object when collected
        CorrectPickupCount++;      // Increment the correct pickup counter

        if (CorrectPickupCount == 10) // When exactly ten correct pickups have happened
        {
            // Find the obstacle spawner in the scene
            var spawner = Object.FindFirstObjectByType<ObstacleSpawner>();
            if (spawner != null)
            {
                // Compute boss spawn position: at spawner's X and middle lane Y
                Vector3 bossPos = new Vector3(
                    spawner.spawnX,
                    spawner.laneYPositions[1],
                    0f
                );
                Instantiate(bossPrefab, bossPos, Quaternion.identity); // Spawn the boss

                spawner.enabled = false; // Disable further obstacle spawning

                if (!other.CompareTag("Player")) // This will never be true here
                {
                    Debug.Log("Correct"); // Log correct branch
                }
                else
                {
                    Debug.Log("Wrong"); // Log wrong branch
                    Destroy(other.gameObject); // This line duplicates earlier destroy
                }
            }
        }
    }
}
