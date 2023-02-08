using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
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