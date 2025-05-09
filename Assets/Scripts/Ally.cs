using UnityEngine;

public class Ally : MonoBehaviour
{
    public GameManager manager;

    void Start()
    {

        // Set the ally to disappear after 3 seconds
        Invoke("Disappear", 3f);  // Call Disappear after 3 seconds
    }

    void Disappear()
    {
      
            // Ensure the gameObject is still valid and not destroyed
            if (gameObject != null && !gameObject.name.StartsWith("AllyOriginal"))
            {
                // Only call the manager method if it's not destroyed
                if (manager != null)
                {
                    manager.AllyEscaped();
                }
                else
                {
                    Debug.LogWarning("Manager reference is null in Ally.");
                }

                // Destroy the clone (not the prefab)
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Attempted to destroy an already destroyed or invalid object.");
            }
        
    }
}
