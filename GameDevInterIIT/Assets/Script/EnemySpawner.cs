using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] spawnLocation;
    public float spawnDelay = 1.0f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnDelay);
    }

    private void SpawnEnemy()
    {
        int spawnIndex=Random.Range(0,spawnLocation.Length);
        Vector3 spawnPosition = spawnLocation[spawnIndex].transform.position;
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[enemyIndex];
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
