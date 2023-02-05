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
    public float jumpForce = 10f;
    private Vector3 moveDir = Vector3.zero;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown("space") && isGrounded){
            jump = true;
        }

        moveDir = new Vector3(h,0,v).normalized;
    }

    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("Map");
        isGrounded = Physics.CheckSphere(foot.position, footOverLapSphereRadius, mask);
        if(isGrounded && jump){
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            jump = false;
        }
        
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    
}
