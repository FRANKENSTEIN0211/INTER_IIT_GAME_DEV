using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform followTarget;
    public Rigidbody rb;
    public Vector2 input = Vector2.zero;
    public Vector3 moveDir = Vector3.zero;

    public float moveSpeed = 10f;
    public float rotateSpeed = 5f;
    public Vector3 followTargetRotation;
    public float minAngle = -60f, maxAngle = 85f;
    void Start()
    {
        followTargetRotation = Vector3.zero;
        rb = gameObject.GetComponent<Rigidbody>();
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
    }

    void FixedUpdate()
    {
        followTarget.eulerAngles = followTargetRotation;
        moveDir = (followTarget.forward * input.y + followTarget.right * input.x).normalized;
        Vector3 vel = moveDir * moveSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);
        
    }

}
