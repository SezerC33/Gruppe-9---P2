using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager manager;
    private bool hasBeenClicked = false;  // Track if the enemy has already been clicked

    void Start()
    {
        Invoke("Escape", 7f); // Call Escape after 7 seconds
    }

    void Escape()
    {
        // Ensure we're destroying the clone, not the prefab
        if (gameObject != null && !gameObject.name.StartsWith("EnemyOriginal"))
        {
            if (manager != null && !hasBeenClicked)
            {
                manager.EnemyEscaped();
                Destroy(gameObject); // Destroy the enemy clone 
            }
            else
            {
                Debug.LogError("Manager is not assigned to the Enemy! Cannot call methods on a null manager.");
            }
        }
    }

    // Add this method to mark the enemy as clicked
    public void OnClick()
    {
        if (!hasBeenClicked)
        {
            hasBeenClicked = true;  // Mark as clicked
            manager.ClickEnemy();  // Award points when clicked
            Destroy(gameObject);  // Destroy the enemy
        }
    }
}
