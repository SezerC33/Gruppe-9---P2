using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string ChangeTo;

    // Make sure the player has the tag "Player"
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            // Load the specified scene
            SceneManager.LoadScene(ChangeTo);
        }
    }
}
