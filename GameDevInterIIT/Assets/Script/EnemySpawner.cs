using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public static int numberOfZombies=5;
    public GameObject[] zombiePrefab;
    private GameObject[] zombies;
    public int currentZombies;

    public RoomGenerator roomGenerator;

    public float spawnDelay = 1.0f;

    private void Start()
    {
        StartLevel();
        
    }

    private void StartLevel()
    {
        
        SpawnZombies(numberOfZombies);
    }

    private void Update()
    {
        CheckForZombieDestruction();
    }

    private void SpawnZombies(int number)
    {
        zombies = new GameObject[number];
        for (int i = 0; i < number; i++)
        {
            int zombieIndex = Random.Range(0, zombiePrefab.Length);
            Vector3 randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-5.0f, 5.0f));
            zombies[i] = Instantiate(zombiePrefab[zombieIndex], transform.position + randomPosition, Quaternion.identity);
        }
        currentZombies = number;
    }

    private void CheckForZombieDestruction()
    {
        int destroyedZombies = 0;
        foreach (GameObject zombie in zombies)
        {
            if (zombie == null)
            {
                destroyedZombies++;
            }
        }
        if (destroyedZombies == currentZombies)
        {
            SpawnNewRoom();
        }
    }

    private void SpawnNewRoom()
    {
        roomGenerator = gameObject.GetComponent<RoomGenerator>();
        SpawnZombies(numberOfZombies);
    }
}

