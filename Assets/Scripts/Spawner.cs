using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public Transform[] spawnPoints; 
    public float initialSpawnDelay = 2f; 
    public float spawnRateDecrease = 0.1f;
    public float minSpawnRate = 0.5f; 

    private float currentSpawnDelay;

    private void Start()
    {
        currentSpawnDelay = initialSpawnDelay;
        Invoke("SpawnEnemy", initialSpawnDelay);
    }

    private void SpawnEnemy()
    {
        int randomPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[randomPrefabIndex];

        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        currentSpawnDelay -= spawnRateDecrease;
        currentSpawnDelay = Mathf.Max(currentSpawnDelay, minSpawnRate);

        Invoke("SpawnEnemy", currentSpawnDelay);
    }
}
