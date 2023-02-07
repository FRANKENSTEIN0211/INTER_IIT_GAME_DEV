using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int maxActiveRooms = 3;
    public List<GameObject> activeRooms = new List<GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown("tab")){
            GenerateNextRoom();
        }
    }

    void GenerateNextRoom(){
        int count = activeRooms.Count;
        GameObject prevRoom = activeRooms[count-1];
        Transform prevEndAnchor = prevRoom.transform.Find("EndAnchor");
        GameObject newRoom = Instantiate(roomPrefab, prevEndAnchor.position, prevEndAnchor.rotation);
        newRoom.transform.SetParent(GameObject.FindGameObjectWithTag("MainMap").transform);
        activeRooms.Add(newRoom);
        if(count > maxActiveRooms){
            GameObject firstRoom = activeRooms[0];
            activeRooms.Remove(firstRoom);
            Destroy(firstRoom);
        }
    }
}