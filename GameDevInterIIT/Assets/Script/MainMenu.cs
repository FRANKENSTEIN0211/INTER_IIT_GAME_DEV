using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Transition Trann = FindObjectOfType<Transition>();
        Trann.LoadLevel1();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

