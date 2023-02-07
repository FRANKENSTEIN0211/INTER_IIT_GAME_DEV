using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimationController : MonoBehaviour
{
    public Animator anim;
    public float animSpeed = 1.5f;
    private string[] AttackAnims = {"Attack_01", "Attack_02", "Attack_03", "Attack_04", "Attack_05"};
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    
    public void Attack(){
        int index = Random.Range(0, AttackAnims.Length);
        anim.SetBool(AttackAnims[index], true);
    }
}
