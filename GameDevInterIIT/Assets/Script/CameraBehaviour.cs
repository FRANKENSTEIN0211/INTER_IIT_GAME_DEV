using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehaviour : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private CinemachineTransposer transposer;
    public Vector3[] followOffsets = {new Vector3(0, 5, -9), new Vector3(0, 8, -1)};
    bool topDownCamera = false;
    public float lerpSpeed = 10f;
    void Start()
    {
        cam = gameObject.GetComponent<CinemachineVirtualCamera>();
        transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
    }
    
    void Update(){
        if(Input.GetKeyDown("v")) topDownCamera = !topDownCamera;
    }

    void LateUpdate(){
        int index = (topDownCamera ? 1 : 0);
        transposer.m_XDamping = topDownCamera ? 0 : 1.2f;
        transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, followOffsets[index], lerpSpeed * Time.deltaTime);
    }   
}
