using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public List<GameObject> aliveEnemies = new List<GameObject>();
    public bool levelClear = false;
    public int maxEnemyCount = 4;
    public int currentEnemyCount = 0;
    public int thisLevel;
    void Update()
    {   
        currentEnemyCount = aliveEnemies.Count;
        if(currentEnemyCount <= 0){
            levelClear = true;
        }else{
            levelClear = false;
        }
    }

    public void StartLevel(){
        SpawnEnemies(maxEnemyCount);
    }

    private void SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-5.0f, 5.0f));
            randomPosition += spawnPoints[spawnIndex].position;
            GameObject newEnemy = Instantiate(enemyPrefabs[enemyIndex], randomPosition, Quaternion.identity);
            newEnemy.transform.SetParent(transform);
            aliveEnemies.Add(newEnemy);
        }
    }
}
