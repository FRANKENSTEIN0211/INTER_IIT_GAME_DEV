using UnityEngine;
using UnityEngine.AI;

public class FollowAgent : MonoBehaviour
{
    private NavMeshAgent agent; 
    public GameObject playerPrefab;
    private GameObject playerInstance;

    private Animator anim;
    private CharacterController controller;
    private bool battle_state;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody Rb;
    private float attackDistance = 3.0f;

    public float deathDelay = 0.8f;

    private bool isDeadTriggered = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController> ();
        Rb=GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        battle_state=false;
        
        playerInstance = GameObject.FindWithTag("Player");
        if (playerInstance == null)
        {
            Debug.LogError("No player found in the scene");
        }
    }

    void Update()
    {
        if (playerInstance != null && !isDeadTriggered)
        {
            float distance = Vector3.Distance(transform.position, playerInstance.transform.position);
            if (GetComponent<Enemy>().currentHealth <= 0f){
                anim.SetBool("IsChasing", false);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsDead", true);
                isDeadTriggered=true;
                Invoke("DestroyEnemy", deathDelay);
            }else if(distance > attackDistance)
            {
                agent.SetDestination(playerInstance.transform.position);
                if(Rb.velocity.magnitude>=0.1f)
                {
                    anim.SetBool("IsAttacking", false);
                    anim.SetBool("IsDead", false);
                    anim.SetBool("IsChasing", true);
                }
                else
                {
                    anim.SetBool("IsChasing", false);
                    anim.SetBool("IsDead", false);
                    anim.SetBool("IsAttacking", false);
                }
            }else
            {
                agent.SetDestination(transform.position);
                battle_state = true;
                anim.SetBool("IsChasing", false);
                anim.SetBool("IsDead", false);
                anim.SetBool("IsAttacking", true);
                //Attack();
            }
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void Attack()
    {
        int val=Random.Range(0,4);
        switch(val%4)
        {
            case 0:
                anim.SetInteger("moving", 1);
                break;
            case 1:
                anim.SetInteger("moving", 2);
                break;
            case 2:
                anim.SetInteger("moving", 3);
                break;
            case 3:
                anim.SetInteger("moving", 4);
                break;
        }
    }
}
