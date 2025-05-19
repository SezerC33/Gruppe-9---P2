using UnityEngine;

[AddComponentMenu("Gameplay/Boss Entry")]
public class BossEntry : MonoBehaviour
{
    [Header("Entry Settings")]
    [Tooltip("Units per second the boss will slide in")]
    [SerializeField] private float entrySpeed = 2f;

    [Tooltip("How many world units to move left when entering")]
    [SerializeField] private float entryDistance = 5f;

    private Vector3 targetPos;

    void OnEnable()
    {
        // compute where we want to end up
        targetPos = transform.position + Vector3.left * entryDistance;
        StartCoroutine(EnterScreen());
    }

    System.Collections.IEnumerator EnterScreen()
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                entrySpeed * Time.deltaTime
            );
            yield return null;
        }
    }
}
