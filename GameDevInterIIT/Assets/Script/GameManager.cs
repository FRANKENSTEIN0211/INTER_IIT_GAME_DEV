using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoomGenerator roomGenerator;
    public float currentLevel;
    public bool levelClear = false;

    void Start()
    {
        roomGenerator = gameObject.GetComponent<RoomGenerator>();
    }

    void Update()
    {
        if(levelClear){
            roomGenerator.GenerateNextRoom();
            currentLevel++;
            levelClear = false;
        }
    }   
}
