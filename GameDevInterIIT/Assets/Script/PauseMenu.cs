using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool isPaused;
    
    private GameObject playerinstance;
    void Start(){
        pauseMenu.SetActive(false);
        playerinstance = GameObject.FindWithTag("Player");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        playerinstance.GetComponent<PlayerController>().enabled = false;
        playerinstance.GetComponent<TimeController>().enabled = false;
        Time.timeScale=0f;
        isPaused=true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        playerinstance.GetComponent<PlayerController>().enabled = true;
        playerinstance.GetComponent<TimeController>().enabled = true;
        Time.timeScale=1f;
        isPaused=false;
    }

    public void BackToMenu()
    {
        Transition Trann = FindObjectOfType<Transition>();
        Time.timeScale=1f;
        Trann.LoadLevel0();
    }

    public void QuitGame()
    {
        Time.timeScale=1f;
        Application.Quit();
    }
}
