using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Array of obstacle prefabs to choose from
    public GameObject[] obstaclePrefabs;

    // Interval between spawns (in seconds)
    public float spawnInterval = 2f;

    // X position where obstacles will be spawned
    public float spawnX = 10f;

    // Y-axis positions corresponding to your lanes
    public float[] laneYPositions = new float[] { -2f, 0f, 2f };

    // Timer to track spawning intervals
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }

    }

    void SpawnObstacle()
    {
        // Randomly choose a lane
        int lane = Random.Range(0, laneYPositions.Length);
        Vector3 spawnPosition = new Vector3(spawnX, laneYPositions[lane], 0f);

        // Randomly choose which obstacle prefab to spawn
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[prefabIndex];

        // Instantiate it
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}