using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public static int numberOfZombies=5;
    public GameObject[] zombiePrefabs;
    private GameObject[] zombies;
    public int currentZombies;

    public static bool isSpawned=false;

    public RoomGenerator roomGenerator;

    public float spawnDelay = 1.0f;

    private void Start()
    {
      isSpawned=false;
    }

    public void StartLevel()
    {    
        SpawnZombies(numberOfZombies);
    }

    private void Update()
    {
        CheckForZombieDestruction();
    }

    private void SpawnZombies(int number)
    {
        Debug.Log(number);
        zombies = new GameObject[number];
        for (int i = 0; i < number; i++)
        {
            int zombieIndex = Random.Range(0, zombiePrefabs.Length);
            Vector3 randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-5.0f, 5.0f));
            zombies[i] = Instantiate(zombiePrefabs[zombieIndex], transform.position + randomPosition, Quaternion.identity);
        }
        currentZombies = number;
    }

    private void CheckForZombieDestruction()
    {
        if(isSpawned){
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
                isSpawned=false;
            }
        }
    }

    private void SpawnNewRoom()
    {
        if (roomGenerator == null)
        {
            Debug.LogError("roomGenerator is null!");
            return;
        }
        roomGenerator = gameObject.GetComponent<RoomGenerator>();
    }




}

