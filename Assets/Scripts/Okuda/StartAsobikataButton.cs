using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class StartAsobikataButton : MonoBehaviour
{
    AudioSource[] audioStartVoice;
    void Start()
    {
        audioStartVoice = GetComponents<AudioSource>();
    }
    public void OnClickAsobikata()
    {
        audioStartVoice[0].Play();
    }
    public void OnClickStart()
    {
        audioStartVoice[0].Play();
    }
    
}
