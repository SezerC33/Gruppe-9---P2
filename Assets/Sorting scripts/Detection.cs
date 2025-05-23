using UnityEngine;
using UnityEngine.SceneManagement;

public class Detection : MonoBehaviour
{
    private static int correctCount = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the box's tag matches the falling object's tag.
        if (other.CompareTag(gameObject.tag))
        {
            // Correct!!
            Debug.Log("Correct!");
            correctCount++;

            if (correctCount >= 10)
            {
                // Load the next scene.
                SceneManager.LoadScene("Past 3");
            }

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
