using System.Collections;
using UnityEngine;
using TMPro; // If using TextMeshPro

public class GameManager : MonoBehaviour
{
    public GameObject EnemyOriginal;
    public GameObject AllyOriginal;
    public Rect spawnArea;
    public TextMeshProUGUI counterText;
    public int counter = 50;
    private bool gameOver = false;

    void Start()
    {
        UpdateCounterText();
        StartCoroutine(SpawnObjects());
    }

    void UpdateCounterText()
    {
        counterText.text = "Counter: " + counter.ToString();
    }

    IEnumerator SpawnObjects()
    {
        while (!gameOver)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(1f); // Spawns something every 1 second
        }
    }

    void SpawnRandomObject()
    {
        // Ensure prefabs are not null before proceeding
        if (EnemyOriginal == null || AllyOriginal == null)
        {
            Debug.LogError("Prefabs are missing! Please assign the prefabs in the inspector.");
            return; // Exit the function if the prefabs are missing
        }

        Vector2 randomPosition = new Vector2(
            Random.Range(spawnArea.xMin, spawnArea.xMax),
            Random.Range(spawnArea.yMin, spawnArea.yMax)
        );

        GameObject prefabToSpawn = (Random.value < 0.5f) ? EnemyOriginal : AllyOriginal;
        GameObject spawnedObject = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

        // Assign a unique name to the spawned object
        if (prefabToSpawn == EnemyOriginal)
        {
            spawnedObject.name = "Enemy_Clone_" + Random.Range(1000, 9999);
        }
        else if (prefabToSpawn == AllyOriginal)
        {
            spawnedObject.name = "Ally_Clone_" + Random.Range(1000, 9999);
        }

        // Set up ClickableObject reference
        ClickableObject clickable = spawnedObject.AddComponent<ClickableObject>();
        clickable.manager = this;

        // Add specific components (Enemy or Ally) based on what was spawned
        if (prefabToSpawn == EnemyOriginal)
        {
            Enemy enemy = spawnedObject.AddComponent<Enemy>();
            enemy.manager = this;
        }
        else if (prefabToSpawn == AllyOriginal)
        {
            Ally ally = spawnedObject.AddComponent<Ally>();
            ally.manager = this;
        }
    }


    public void ClickEnemy()
    {
        if (gameOver) return;
        counter += 10;
        CheckGameOver();
        UpdateCounterText();
    }

    public void ClickAlly()
    {
        if (gameOver) return;
        counter -= 10;
        CheckGameOver();
        UpdateCounterText();
    }

    public void EnemyEscaped()
    {
        if (gameOver) return;
        counter -= 5;
        CheckGameOver();
        UpdateCounterText();
    }

    public void AllyEscaped()
    {
        if (gameOver) return;
        counter += 0;
        CheckGameOver();
        UpdateCounterText();
    }


    void CheckGameOver()
    {
        // Check for game over (score >= 100 or score == 0)
        if (counter >= 100)
        {
            gameOver = false;
            Debug.Log("You won!");
            // Show a message to the player here or load a "Win" scene
        }
        else if (counter <= 0)
        {
            gameOver = true;
            Debug.Log("Game over 0!");
            // Show a Game over screen
        }
    }
}