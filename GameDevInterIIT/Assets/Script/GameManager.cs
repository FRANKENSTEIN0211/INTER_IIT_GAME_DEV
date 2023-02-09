using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoomGenerator roomGenerator;
    private GameObject currentRoom;
    private RoomManager currentRoomManager;
    public int currentLevel;
    public bool levelClear = false;
    public GameObject[] enemyPrefabs;

    void Start()
    {
        currentLevel = 1;
        roomGenerator = gameObject.GetComponent<RoomGenerator>();
        currentRoom = roomGenerator.activeRooms[0];
        currentRoomManager = currentRoom.GetComponent<RoomManager>();
        currentRoomManager.enemyPrefabs = enemyPrefabs;
        currentRoomManager.maxEnemyCount = currentLevel;
        currentRoomManager.thisLevel = currentLevel;
        currentRoomManager.StartLevel();
    }

    void Update()
    {
        if(levelClear){
            currentRoom = roomGenerator.GenerateNextRoom();
            currentLevel++;
            currentRoomManager = currentRoom.GetComponent<RoomManager>();
            currentRoomManager.enemyPrefabs = enemyPrefabs;
            currentRoomManager.maxEnemyCount = currentLevel;
            currentRoomManager.thisLevel = currentLevel;
            currentRoomManager.StartLevel();
        }

        levelClear = currentRoomManager.levelClear;
    }   
}
