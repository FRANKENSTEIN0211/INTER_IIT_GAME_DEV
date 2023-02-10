using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    Animator animator;
    private string[] DamageAnims = { "Hit_01", "Hit_02" };
    public static int highScore;
    public GameObject scorecard;
    [SerializeField]
    private AudioSource blood;
    public AudioClip bloodAudio;
    public GameObject player;

    private bool healthSpawned=false;

    public GameObject healthOrbPrefab;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        highScore=0;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if (currentHealth > 0 && damage>0)
        {
            int index = UnityEngine.Random.Range(0, DamageAnims.Length);
            animator.SetTrigger(DamageAnims[index]);
            //Debug.Log("damage");
            gameObject.GetComponent<Cinemachine.CinemachineImpulseSource>().GenerateImpulse();
            blood.PlayOneShot(bloodAudio);
        }


        if(currentHealth <= 0){
            if(!healthSpawned)
            {    Vector3 spawnPosition = transform.position;
                spawnPosition.y += 2f;
                GameObject orb = Instantiate(healthOrbPrefab, spawnPosition, Quaternion.identity);
                Vector3 rot = transform.rotation.eulerAngles;
                rot.x = -90;
                orb.transform.rotation = Quaternion.Euler(rot);
            }
            healthSpawned=true;
            Die();
        }

    }

    void Die(){
        //Debug.Log("Ded");
    }

}