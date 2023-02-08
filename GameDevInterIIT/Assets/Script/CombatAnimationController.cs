using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimationController : MonoBehaviour
{
    Animator anim;
    public float animSpeed = 1.5f;
    private string[] AttackAnims = {"Attack_01", "Attack_02", "Attack_03", "Attack_04", "Attack_05"};
    // private string[] AttackAnims = {"Attack_02"};
    private string[] DamageAnims = { "Damage_01","Damage_02" };
    [SerializeField] GameObject attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
    public void AttackAnim(){
        int index = Random.Range(0, AttackAnims.Length);
        anim.SetBool(AttackAnims[index], true);
    }
    public void TakeDamageAnim()
    {
        int index = Random.Range(0, DamageAnims.Length);
        anim.SetBool(DamageAnims[index],true);
    }
    public void Death()
    {
        anim.SetBool("Dead_02", true);
    }
}
