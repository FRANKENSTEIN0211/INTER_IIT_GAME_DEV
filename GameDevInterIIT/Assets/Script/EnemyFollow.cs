using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class EnemyFollow : MonoBehaviour
{
    public GameObject myTarget;
 
    public NavMeshAgent myAgent;
    // Start is called before the first frame update
    void Start()
    {
 
    }

     // Update is called once per frame
    void Update()
    {
        if(myTarget != null)
        {
            myAgent.destination = myTarget.transform.position;
            Debug.Log(myAgent.destination);
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered");
        if(other.tag == "Player")
        {
            myTarget = other.gameObject;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myTarget = null;
        }
    }
}