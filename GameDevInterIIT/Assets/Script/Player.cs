using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 1f;
    public float nextAttackTime = 0f;
    public LayerMask enemyLayer;
    void Update()
    {
        if(Time.time >= nextAttackTime){   
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                // Debug.Log(Time.time);
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
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
