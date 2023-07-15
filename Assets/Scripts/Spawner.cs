using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform[] spawnPoints; 

    private void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            SpawnEnemy(spawnPoint.position);
        }
    }

    private void SpawnEnemy(Vector3 spawnPosition)
    {
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
