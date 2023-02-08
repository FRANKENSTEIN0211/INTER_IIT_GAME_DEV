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
    [SerializeField] float playerHealth = 100f;
    public int maxHealth = 0;
    public int currentHealth;
    PlayerController playerController;
    public GameObject[] bloodPrefabs;
    public Transform hitPoint;
    void Start(){
        combatAnim = gameObject.GetComponent<CombatAnimationController>();
        playerController = gameObject.GetComponent<PlayerController>();
        currentHealth = maxHealth;
    }
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("mouse0 pressed");
                combatAnim.AttackAnim();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack()
    {
        //Attack anim

        //Enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            // Debug.Log(enemy.GetComponent<Enemy>().currentHealth);

            Vector3 direction = attackPoint.position;
            hitPoint = enemy.transform;
            float angle = transform.rotation.eulerAngles.y + 180;
            Debug.Log(angle);
            GameObject bloodPrefab = bloodPrefabs[Random.Range(0, bloodPrefabs.Length)];
            var instance = Instantiate(bloodPrefab, hitPoint.position, Quaternion.Euler(0, angle+90, 0));
            Destroy(instance, 5f);
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        combatAnim.TakeDamageAnim();
        if (currentHealth <= 0)
        {
            PlayerDie();
        }

    }
    void PlayerDie()
    {
        playerController.enabled = false;
        combatAnim.enabled = false;
        combatAnim.Death();
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
