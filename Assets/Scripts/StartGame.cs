using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Changes scene when you click button
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Future Standard", LoadSceneMode.Single);
    }
}

