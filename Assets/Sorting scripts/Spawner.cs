using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] spawner; // Array of prefabs to spawn
    public float SpawnRate = 2.0f; // Time between spawns in seconds
    private float timer = 0; // Tracks time since last spawn
    public float PositionX = 10; // Horizontal range for random spawn offset

    private void Start() // Called before the first frame update
    {
        // Instantiate one of each object at the spawner's position on start
        foreach (GameObject obj in spawner)
        {
            Instantiate(obj, transform.position, transform.rotation);
        }
    }

    private void Update() // Called once per frame
    {
        timer += Time.deltaTime; // Increment timer by time since last frame
        if (timer >= SpawnRate) // Check if it's time to spawn a new object
        {
            SpawnMethod(); // Spawn a random object
            timer = 0; // Reset timer
        }
    }

    void SpawnMethod() // Handles spawning a random object within the horizontal range
    {
        // Determine random X position within +/- PositionX of the spawner
        float LowestPoint = transform.position.x - PositionX;
        float HighestPoint = transform.position.x + PositionX;
        Vector3 spawnPosition = new Vector3(
            Random.Range(LowestPoint, HighestPoint), // Random X between lowest and highest
            transform.position.y, // Same Y as spawner
            0 // Z coordinate at 0 for 2D
        );

        // Choose a random prefab from the array
        int RandomSpawner = Random.Range(0, spawner.Length);
        GameObject objectToSpawn = spawner[RandomSpawner];

        // Instantiate the chosen prefab at the random position
        Instantiate(objectToSpawn, spawnPosition, transform.rotation);
    }
}
