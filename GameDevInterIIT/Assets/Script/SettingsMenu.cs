using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer MainMixer;
    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen=isFullScreen;

    }

    public void SetVolume(float volume){
       MainMixer.SetFloat("Volume",volume);
    }
}
