using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int highScore=0;
    public TextMeshProUGUI scoreText;

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
        scoreText.text="SCORE: "+highScore.ToString();
    }
}
