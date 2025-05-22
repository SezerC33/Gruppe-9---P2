using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDestroy : MonoBehaviour
{
    [Tooltip("Number of taps required to destroy the boss")]
    public int tapsToDestroy = 10;

    private int _tapCount = 0;

    void OnMouseDown()
    {
        _tapCount++;
        Debug.Log($"Boss tapped {_tapCount}/{tapsToDestroy} times");

        if (_tapCount >= tapsToDestroy)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Past 1");
        }
    }
}
