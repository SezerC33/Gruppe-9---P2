using UnityEngine;

public class TrashMove : MonoBehaviour
{
    // Speed at which the obstacle moves to the left
    public float speed = 5f;

    void Update()
    {
        // Move left every frame
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
