using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject Bullets;

    [Header("Distance Between Player")]
    [SerializeField] float MaxDis = 5000f;
    [SerializeField] float MinDis = 500f;
    float DisBtw;

    [Header("Enemy Constraints")]
    [SerializeField] int EnemyHealth = 10;
    [SerializeField] float EnemySpeed = 1f;
    [SerializeField] float DestroyTime = 3f;
    [SerializeField] Transform Gun;

    [Header("Bullet Constraints")]
    [SerializeField] float BulletLifeTime = 5f;
    [SerializeField] float TimeBtwShots = 3f;
    bool IsShoot = true;

    void Start()
    {
        Debug.Log(MinDis);
    }

    void FixedUpdate()
    {
        DisBtw = Vector3.Distance(player.transform.position, transform.position);

        if (DisBtw > MinDis && DisBtw < MaxDis)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, EnemySpeed * Time.deltaTime);
        }

        Debug.Log(DisBtw);
        if (IsShoot && DisBtw <= MinDis)
        {
            Debug.Log("fired");
            StartCoroutine(Fire());
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player get collided with player, accidently or intentionally
        //kill the player instantly and take some damge.
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    //function for taking damage
    void TakeDamage()
    {
        EnemyHealth--;
        if (EnemyHealth <= 0) { Destroy(gameObject, DestroyTime); }
    }

    //the function call for firing the bullet.
    IEnumerator Fire()
    {
        //instantiate the bullet as gameobject 
        //wait until the time between shots to complete and fire again.
        IsShoot = false;
        var direction = (player.transform.position - transform.position).normalized;
        GameObject Bullet = Instantiate(Bullets, transform.position + direction, transform.rotation);
        Bullet.GetComponent<Rigidbody>().velocity = direction*8;

        Debug.Log("bullet");
        Debug.Log(Bullet.transform.position);
        Destroy(Bullet, BulletLifeTime);
        yield return new WaitForSeconds(TimeBtwShots);
        IsShoot = true;
    }

}