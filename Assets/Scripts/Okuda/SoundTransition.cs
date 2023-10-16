using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class SoundTransition : MonoBehaviour
{
    AudioSource[] audioTransition;
    // Start is called before the first frame update
    void Start()
    {
        audioTransition = GetComponents<AudioSource>();
        Invoke("PlayAudioKiritan", 3.0f);

    }
    //Ç´ÇËÇΩÇÒÇÃçUåÇâπ
    void PlayAudioKiritan()
    {
        audioTransition[1].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
