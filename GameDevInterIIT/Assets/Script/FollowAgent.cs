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

    private string[] AttackAnims = {"Attack_01", "Attack_02", "Attack_03", "Attack_04"};
    private string[] DeathAnims = {"Dead_01", "Dead_02"};
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
                int index = Random.Range(0, DeathAnims.Length);
                anim.SetBool(DeathAnims[index], true);
                isDeadTriggered=true;
                Invoke("DestroyEnemy", deathDelay);
            }else if(distance > attackDistance)
            {
                agent.SetDestination(playerInstance.transform.position);
                if(Rb.velocity.magnitude>=0.1f)
                {
                    anim.SetBool("IsChasing", true);
                }
                else
                {
                    anim.SetBool("IsChasing", false);
                }
            }else
            {
                agent.SetDestination(transform.position);
                battle_state = true;
                anim.SetBool("IsChasing", false);
                Attack();
            }
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void Attack(){
        int index = Random.Range(0, AttackAnims.Length);
        anim.SetBool(AttackAnims[index], true);
    }
}
