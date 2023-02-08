using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // [SerializeField] GameObject player;

    // [Header("Distance Between Player")]
    // [SerializeField] float MaxDis = 5000f;
    // [SerializeField] float MinDis = 500f;
    // float DisBtw;

    // [Header("Enemy Constraints")]
    // [SerializeField] float EnemyHealth = 100f;
    // [SerializeField] float EnemySpeed = 1f;
    // [SerializeField] float TimeBtwShots = 3f;
    // [SerializeField] float DestroyTime = 3f;
    // [SerializeField] float WarningTime = 0.5f;
    // [SerializeField] float DamageRange = 1f;
    // [SerializeField] float Damage = 10f;

    // bool IsAttack = true;

    // void Start()
    // {
    //     Debug.Log(MinDis);
    // }

    // void FixedUpdate()
    // {
    //     if(EnemyHealth > 0){
    //         DisBtw = Vector3.Distance(player.transform.position, transform.position);
    //         // Debug.Log(DisBtw);
    //         if (IsAttack && DisBtw <= MinDis)
    //         {
    //             Debug.Log("fired");
    //             StartCoroutine(Attack());
    //         }
    //     }
    // }

    // //function for taking damage
    // public void TakeDamage(float damage)
    // {
    //     EnemyHealth -= damage;
    //     if (EnemyHealth <= 0){
    //         Destroy(gameObject, DestroyTime);
    //     }
    // }

    // //the function call for firing the bullet.
    // IEnumerator Attack()
    // {
    //     //instantiate the bullet as gameobject 
    //     //wait until the time between shots to complete and fire again.
    //     IsAttack = false;
    //     yield return new WaitForSeconds(WarningTime);
    //     var direction = (player.transform.position - transform.position).normalized;

    //     // Play Attack Animation
    //     // if(DisBtw < DamageRange){
    //     //     Player.TakeDamage(Damage);
    //     //     //Player Damage animation
    //     // }

    //     yield return new WaitForSeconds(TimeBtwShots);
    //     IsAttack = true;
    // }

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;

        // hurt animation

        if(currentHealth <= 0){
            Die();
        }

    }

    void Die(){
        Debug.Log("Ded");
    }

}