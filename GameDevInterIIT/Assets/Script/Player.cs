using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform attackPoint;
    public CombatAnimationController combatAnim;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 1f;
    public float nextAttackTime = 0f;
    public LayerMask enemyLayer;
    public GameObject[] bloodPrefabs;
    public Transform hitPoint;

    void Start(){
        combatAnim = gameObject.GetComponent<CombatAnimationController>();
    }
    void Update()
    {
        if(Time.time >= nextAttackTime){   
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                combatAnim.Attack();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
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

    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
