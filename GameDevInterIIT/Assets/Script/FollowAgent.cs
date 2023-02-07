using UnityEngine;
using UnityEngine.AI;

public class FollowAgent : MonoBehaviour
{
    private NavMeshAgent agent; // The NavMeshAgent component on this game object
    public GameObject playerPrefab;
    private GameObject playerInstance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        // Find the instance of the player in the scene
        playerInstance = GameObject.FindWithTag("Player");
        if (playerInstance == null)
        {
            Debug.LogError("No player found in the scene");
        }
    }

    void Update()
    {
        if (playerInstance != null)
        {
            agent.SetDestination(playerInstance.transform.position);
        }
    }
}
