using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 1f;
    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadLevel1()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevel0()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadLevel3()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 0));
    }

    IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}