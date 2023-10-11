using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class StartAsobikataButton : MonoBehaviour
{
    AudioSource[] audioStartVoice;
    public GameObject SMObject;
    void Start()
    {
        audioStartVoice = GetComponents<AudioSource>();
    }
    public void OnClickAsobikata()
    {
        audioStartVoice[0].Play();
        AudioSource[] pauseAudio = SMObject.GetComponents<AudioSource>();
        pauseAudio[1].Pause();
    }
    public void OnClickStart()
    {
        audioStartVoice[0].Play();
        AudioSource[] pauseAudio = SMObject.GetComponents<AudioSource>();
        pauseAudio[1].Pause();
    }
    
}
