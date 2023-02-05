using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform foot;
    public float footOverLapSphereRadius = 0.1f;
    public bool isGrounded = false;
    public bool jump = false;
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public Vector3 moveDir = Vector3.zero;

    float xmove;
    float zmove;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        xmove = Input.GetAxisRaw("Horizontal");
        zmove = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown("space") && isGrounded){
            jump = true;
        }
    }

    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("Map");
        isGrounded = Physics.CheckSphere(foot.position, footOverLapSphereRadius, mask);

        rb.velocity = new Vector3(xmove*moveSpeed,rb.velocity.y,zmove*moveSpeed);

        if(isGrounded){
            if(jump){
                rb.velocity=new Vector3(rb.velocity.x,jumpSpeed,rb.velocity.z);
                jump = false;
            }
        }
    }

    
}
