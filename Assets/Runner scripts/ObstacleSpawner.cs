using UnityEngine; // Access Unity's core engine features

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs to instantiate
    public float spawnInterval = 2f;    // Time between spawns in seconds
    public float spawnX = 10f;          // X-coordinate where obstacles appear
    public float[] laneYPositions = new float[] { -3f, 0f, 3f }; // Y-positions for lanes

    private float timer = 0f; // Tracks time since last spawn

    void Update() // Called once per frame
    {
        timer += Time.deltaTime; // Increment timer by time since last frame

        if (timer >= spawnInterval) // If enough time has passed
        {
            SpawnObstacle(); // Create a new obstacle
            timer = 0f;      // Reset the timer
        }
    }

    void SpawnObstacle() // Handles obstacle instantiation
    {
        int lane = Random.Range(0, laneYPositions.Length); // Pick a random lane index
        Vector3 spawnPosition = new Vector3(spawnX, laneYPositions[lane], 0f); // Compute spawn position

        int prefabIndex = Random.Range(0, obstaclePrefabs.Length); // Pick a random obstacle prefab
        GameObject selectedPrefab = obstaclePrefabs[prefabIndex];   // Get the chosen prefab

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity); // Spawn it at the position
    }
}
