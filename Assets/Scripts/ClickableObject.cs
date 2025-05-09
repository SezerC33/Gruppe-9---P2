using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameManager manager;

    private void OnMouseDown()
    {
        // Only destroy the clicked object (the clone)
        if (gameObject != null)
        {
            if (CompareTag("Enemy"))
            {
                manager.ClickEnemy();  // Call GameManager's method when enemy is clicked
            }
            else if (CompareTag("Ally"))
            {
                manager.ClickAlly();  // Call GameManager's method when ally is clicked
            }

            // Destroy the clicked object (clone), not the original
            Destroy(gameObject);
        }
    }
}