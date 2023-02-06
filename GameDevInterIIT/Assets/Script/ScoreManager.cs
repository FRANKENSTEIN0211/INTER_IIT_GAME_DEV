using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int highScore=0;

    public bool IsDead;
    public GameObject endMenu;

    // Start is called before the first frame update
    void Start()
    {
        highScore=0;
        IsDead=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsDead)
            highScore++;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Handle the collision
        if(collision.gameObject.tag=="Player"){
                endMenu.SetActive(true);
                IsDead=true;
                Time.timeScale=0f;
        }
    }
}
