using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public PlayerController playerController;
    public Animator animator;
    public Player player;
    public float normalTimeScale = 1.0f;
    public float slowTimeScale = 0.5f;
    public float lerpSpeed = 15f;
    public bool slowMo;
    [SerializeField] public static float timePower = 100f;
    private GameObject timeBar;
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        animator = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<Player>();
        timeBar=GameObject.Find("Time_Bar");
        timePower=100f;
        timeBar.GetComponent<Slider>().value = timePower;
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
                //Debug.Log(Time.timeScale);
                timePower -= Time.unscaledDeltaTime*15f;
                player.attackRate = player.initialAttackRate/Time.timeScale;
            }
            timeBar.GetComponent<Slider>().value = timePower;
        }else{
            slowMo = false;
            Time.timeScale = Mathf.Lerp(Time.timeScale, normalTimeScale, lerpSpeed * Time.deltaTime);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            if(timePower<100)
            {
                timePower += Time.unscaledDeltaTime*2f;
                timeBar.GetComponent<Slider>().value = timePower;
            }
            animator.speed = 1/Time.timeScale;
        }
    }
}
