using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 1f;
    public float spawnRangeX = 8f;
    public float spawnY = 6f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
