using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDestroy : MonoBehaviour // Makes the boss object destroyable via tapping
{
    public int tapsToDestroy = 10; // Number of taps required to destroy the boss

    private int _tapCount = 0; // Tracks how many times the boss has been tapped

    void OnMouseDown() // Called when the object is clicked or tapped
    {
        _tapCount++; // Increment tap count each click
        Debug.Log($"Boss tapped {_tapCount}/{tapsToDestroy} times"); // Log progress

        if (_tapCount >= tapsToDestroy) // Check if required taps reached
        {
            Destroy(gameObject); // Remove the boss from the scene
            SceneManager.LoadScene("Past 1"); // Load the next scene
        }
    }
}