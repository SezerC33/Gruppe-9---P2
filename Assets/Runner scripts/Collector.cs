using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public int CorrectPickupCount { get; private set; }

    // Drag your boss-obstacle prefab into this slot in the Inspector
    public GameObject bossPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Destroy(other.gameObject);
        CorrectPickupCount++;

        // the magic happens when we hit exactly 10
        if (CorrectPickupCount == 10)
        {
            var spawner = Object.FindFirstObjectByType<ObstacleSpawner>();
            if (spawner != null)
            {
                // 1) Spawn the boss at the same X as normal obstacles,
                //    and in the middle lane (laneYPositions[1])—
                //    tweak [1] if you want a different lane.
                Vector3 bossPos = new Vector3(
                    spawner.spawnX,
                    spawner.laneYPositions[1],
                    0f
                );
                Instantiate(bossPrefab, bossPos, Quaternion.identity);

                // 2) Turn off the spawner so no more little obstacles come
                spawner.enabled = false;

                if (!other.CompareTag("Player"))
                {
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("Wrong");

                    Destroy(other.gameObject);
                }
            }
        }
    }
}
