using UnityEngine;
using UnityEngine.AI;

public class FollowAgent : MonoBehaviour
{
    public Transform target; // The main player's transform
    private NavMeshAgent agent; // The NavMeshAgent component on this game object
    public float climbHeight = 3f; // The height of the stairs

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
