using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * moveSpeed * Time.deltaTime;
        v = v * moveSpeed * Time.deltaTime;

        transform.position += new Vector3(h, 0, v);
    }
}
