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

    public float nextAttackTime = 0f;
    public float attackRate = 1f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public Transform hitPoint;
    public GameObject[] bloodPrefabs;
    public LayerMask playerLayer;
    Enemy enemy;

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
        enemy = GetComponent<Enemy>();
        
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
            if (enemy.currentHealth <= 0f){
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
                if(Time.time >= nextAttackTime){
                    EnemyAttack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
        enemy.TakeDamage(0);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void EnemyAttack(){
        if (enemy.currentHealth > 0)
        {
            int index = Random.Range(0, AttackAnims.Length);
            anim.SetBool(AttackAnims[index], true);
        }
    }
    public void GivePlayerDamage()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<Player>().TakeDamage(attackDamage);
            // Debug.Log(enemy.GetComponent<Enemy>().currentHealth);

            Vector3 direction = attackPoint.position;
            hitPoint = player.transform;
            float angle = transform.rotation.eulerAngles.y + 180;
            Debug.Log(angle);
            GameObject bloodPrefab = bloodPrefabs[Random.Range(0, bloodPrefabs.Length)];
            var instance = Instantiate(bloodPrefab, hitPoint.position, Quaternion.Euler(0, angle + 90, 0));
            Destroy(instance, 5f);
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
