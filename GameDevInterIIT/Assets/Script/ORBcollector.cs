using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORBcollector : MonoBehaviour
{
    private GameObject managerInstance;

    // Start is called before the first frame update
    void Start()
    {
        managerInstance = GameObject.Find("Game_Manager");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag=="Player"){
            Debug.Log("collission");
            EnemySpawner.isSpawned=true;
            managerInstance.GetComponent<EnemySpawner>().StartLevel();
            Destroy(gameObject);
        }
    }
}
