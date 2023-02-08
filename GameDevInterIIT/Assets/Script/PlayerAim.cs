using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAim : MonoBehaviour
{
    public PlayerController playerMovementScript;
    public Rigidbody rb;
    private Vector3 lookDir = Vector3.zero;
    private Vector3 old_mouse_position = Vector3.zero;
    public float coolDownTime = 1f, CoolDownTimer = 0;
    public float lerpTime = 10f;
    public Vector3 targetLookDir = Vector3.zero;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        playerMovementScript = gameObject.GetComponent<PlayerController>();
    }
    void Update()
    {  
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cameraRayHit;
        if (Physics.Raycast(cameraRay, out cameraRayHit)){
            Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
            targetLookDir = (targetPosition-transform.position).normalized;
        }

    
        if(Input.GetMouseButton(1)){
            //transform.Rotate(new Vector3(0, Vector3.SignedAngle(transform.forward, lookDir, new Vector3(0,1,0)), 0));
            lookDir = Vector3.Lerp(lookDir, targetLookDir, lerpTime * Time.deltaTime);
            transform.forward = lookDir;
        }else{
            Vector3 moveDir = playerMovementScript.moveDir;
            if(moveDir != Vector3.zero) lookDir = Vector3.Lerp(lookDir, moveDir, lerpTime * Time.deltaTime);
            lookDir.y = transform.forward.y;
            transform.forward = lookDir;
        }
    }

}

