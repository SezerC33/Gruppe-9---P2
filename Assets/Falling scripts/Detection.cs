using UnityEngine;

public class Detection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the box's tag matches the falling object's tag.
        if (other.CompareTag(gameObject.tag))
        {
            // Correct!!
            Debug.Log("GADDAM!");
            
        }
        else
        {
            // Íncorrect!
            Debug.Log("Wrong!");
            
        }

        // Removes the falling objects.
        // Built-in unity method.
        Destroy(gameObject);
    }
}
