using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform attackPoint;
    CombatAnimationController combatAnim;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 1f;
    public float nextAttackTime = 0f;
    public LayerMask enemyLayer;
    public int maxHealth = 100;
    public int currentHealth;
    PlayerController playerController;
    public GameObject[] bloodPrefabs;
    public Transform hitPoint;
    public float initialAttackRate = 1.5f;
    public GameObject endMenu;

    [SerializeField]
    private AudioSource sword;
    public AudioClip whoosh;
    private GameObject playerinstance;
    public static int hitCount=0;

    [SerializeField]
    private AudioSource hurt;
    public AudioClip playerHurt;

    [SerializeField]
    private AudioSource death;
    public AudioClip playerDeath;
    void Start(){
        combatAnim = gameObject.GetComponent<CombatAnimationController>();
        playerController = gameObject.GetComponent<PlayerController>();
        currentHealth = maxHealth;
        playerinstance = GameObject.FindWithTag("Player");
        hitCount=0;
    }
    void Update()
    {
        if (!playerController.wasJumping)
        {

            if(Time.time >= nextAttackTime){
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("mouse0 pressed");
                    combatAnim.AttackAnim();
                    //Attack();
                    sword.PlayOneShot(whoosh, 0.7f);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    public void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            if(enemy.GetComponent<Enemy>().currentHealth > 0){
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                Vector3 direction = attackPoint.position;
                hitPoint = enemy.transform;
                float angle = transform.rotation.eulerAngles.y + 180;
                GameObject bloodPrefab = bloodPrefabs[Random.Range(0, bloodPrefabs.Length)];
                var instance = Instantiate(bloodPrefab, hitPoint.position, Quaternion.Euler(0, angle+90, 0));
                Destroy(instance, 5f);
                hitCount++;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hurt.PlayOneShot(playerHurt);
        combatAnim.TakeDamageAnim();
        if (currentHealth <= 0)
        {
            PlayerDie();
            endMenu.SetActive(true);
            playerinstance.GetComponent<PlayerController>().enabled = false;
            playerinstance.GetComponent<TimeController>().enabled = false;
            Time.timeScale=0f;
        }

    }
    void PlayerDie()
    {
        playerController.enabled = false;
        combatAnim.enabled = false;
        death.PlayOneShot(playerDeath);
        gameObject.GetComponent<Player>().enabled = false;
        combatAnim.Death();
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
