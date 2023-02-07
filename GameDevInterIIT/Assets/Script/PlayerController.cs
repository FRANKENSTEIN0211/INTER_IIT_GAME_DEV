using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform followTarget, foot;
    public Rigidbody rb;
    public Vector2 input = Vector2.zero;
    public Vector3 moveDir = Vector3.zero;

    public float moveSpeed = 10f;
    public float rotateSpeed = 5f;
    public float jumpSpeed = 10f;
    public Vector3 followTargetRotation;
    public float minAngle = -60f, maxAngle = 85f;
    public bool isGrounded = true, jump = false;
    public float footOverLapSphereRadius = 0.1f;

    LayerMask mask;
    void Start()
    {
        followTargetRotation = Vector3.zero;
        rb = gameObject.GetComponent<Rigidbody>();
        mask = LayerMask.GetMask("Map");
    }
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        followTargetRotation.y += mouseX * rotateSpeed * Time.deltaTime;
        followTargetRotation.x -= mouseY * rotateSpeed * Time.deltaTime;    
        followTargetRotation.x = Mathf.Clamp(followTargetRotation.x, minAngle, maxAngle);

        if(Input.GetKeyDown("space") && isGrounded){
            jump = true;
        }
    }

    void FixedUpdate()
    {
        
        isGrounded = Physics.CheckSphere(foot.position, footOverLapSphereRadius, mask);

        followTarget.eulerAngles = followTargetRotation;
        moveDir = (followTarget.forward * input.y + followTarget.right * input.x).normalized;
        Vector3 vel = moveDir * moveSpeed * Time.fixedDeltaTime;

        if(isGrounded && jump){
            vel.y = jumpSpeed;
            jump = false;
        }else vel.y = rb.velocity.y;

        rb.velocity = vel;
    }

}
