using UnityEngine;

// Makes camera follow Character
public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    void LateUpdate() =>
        transform.position = target ? (Vector3)(target.position) + new Vector3(0, 0, -10) : transform.position;
}