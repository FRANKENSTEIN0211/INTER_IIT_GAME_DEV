using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehaviour : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private CinemachineTransposer transposer;
    public GameObject Player;
    public Vector3[] followOffsets = {new Vector3(0, 20, -21), new Vector3(0, 20, -2)};
    public float FOV = 40f;
    bool topDownCamera = false;
    public float lerpSpeed = 1f;
    public float ScrollIncrement = 1f;
    public float minFOV = 20f, maxFOV = 60f;
    void Start()
    {
        cam = gameObject.GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindGameObjectWithTag("Player");
        cam.Follow = Player.transform;
        cam.LookAt = Player.transform;
        cam.m_Lens.FieldOfView = FOV;
        transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
    }
    
    void Update(){
        if(Input.GetKeyDown("v")) topDownCamera = !topDownCamera;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        FOV += -Input.mouseScrollDelta.y * ScrollIncrement;
    }

    void LateUpdate(){
        cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, FOV, lerpSpeed * Time.deltaTime);
        int index = (topDownCamera ? 1 : 0);
        transposer.m_XDamping = topDownCamera ? 0 : 1.2f;
        transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, followOffsets[index], lerpSpeed * Time.deltaTime);
    }   
}
