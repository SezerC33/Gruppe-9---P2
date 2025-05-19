using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] spawner;
    public float SpawnRate = 2.0f;
    private float timer = 0;
    public float PositionX = 10;


    private void Start()
    {
        foreach (GameObject obj in spawner)
        {
            Instantiate(obj, transform.position, transform.rotation);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnRate)
        {
            SpawnMethod();
            timer = 0;
        }
    }


    void SpawnMethod()
    {
        float LowestPoint = transform.position.x - PositionX;
        float HighestPoint = transform.position.x + PositionX;
        Vector3 spawnPosition = new Vector3(Random.Range(LowestPoint, HighestPoint), transform.position.y, 0);

        int RandomSpawner = Random.Range(0, spawner.Length);
        GameObject objectToSpawn = spawner[RandomSpawner];

        Instantiate(objectToSpawn, spawnPosition, transform.rotation);

    }
}


