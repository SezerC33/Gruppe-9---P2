using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    void Start()
    {
        // Ensure the tree has a BoxCollider2D
        if (GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<PolygonCollider2D>();
        }

        // Set the collider to be solid (not a trigger)
        GetComponent<PolygonCollider2D>().isTrigger = false;
    }
}
