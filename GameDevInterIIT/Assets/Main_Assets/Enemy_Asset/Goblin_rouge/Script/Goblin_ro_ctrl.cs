using UnityEngine;
using System.Collections;

public class Goblin_ro_ctrl : MonoBehaviour {
	
	
	private Animator anim;
	private CharacterController controller;
	private bool battle_state;
	private Vector3 moveDirection = Vector3.zero;
	private Rigidbody Rb;

	public float deathDelay = 3.0f;
	
	
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
		Rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Rb.velocity.magnitude>=0.1f){
			anim.SetInteger ("moving", 2);//run
		}else{
			anim.SetInteger("battle", 1);
			battle_state = true;
		}

		if (GetComponent<Enemy>().currentHealth<=0f)
		{
			int val=Random.Range(0,1);
			if(val%2==0f)
				anim.SetInteger("moving", 13);
			else
				anim.SetInteger("moving", 12);
			
			Invoke("DestroyEnemy", deathDelay);
		}	
	}

	private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

	private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag=="Player"){
			int val=Random.Range(0,2);
			anim.SetInteger("battle", 0);
			battle_state = false;
			if(val%3==0f)
				anim.SetInteger("moving", 3);
			if(val%3==1f)
				anim.SetInteger("moving", 4);
			if(val%3==2f)
				anim.SetInteger("moving", 5);
		}
    }
}

