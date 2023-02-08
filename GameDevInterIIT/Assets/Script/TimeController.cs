using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public PlayerController playerController;
    public Animator animator;
    public Player player;
    public float normalTimeScale = 1.0f;
    public float slowTimeScale = 0.5f;
    public float lerpSpeed = 15f;
    public bool slowMo;
    [SerializeField] float timePower = 100f;
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        animator = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<Player>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.R)){
            if (timePower > 0)
            {
                slowMo = true;
                Time.timeScale = Mathf.Lerp(Time.timeScale, slowTimeScale, lerpSpeed * Time.deltaTime);
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                animator.speed = 1/Time.timeScale;  
                Debug.Log(Time.timeScale);
                timePower -= Time.unscaledDeltaTime*10f;
                player.attackRate = player.initialAttackRate/Time.timeScale;
            }
        }
        else{
            slowMo = false;
            Time.timeScale = Mathf.Lerp(Time.timeScale, normalTimeScale, lerpSpeed * Time.deltaTime);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            animator.speed = 1/Time.timeScale;
        }
    }
}
