using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class SoundClear : MonoBehaviour
{
    AudioSource[] audioClear;
    // Start is called before the first frame update
    void Start()
    {
        audioClear = GetComponents<AudioSource>();
        Invoke("PlayAudioClear", 1.8f);
        Invoke("PlayAudioFun", 3.9f);

    }
    //Ç´ÇËÇΩÇÒÇÃçUåÇâπ
    void PlayAudioClear()
    {
        audioClear[1].Play();
    }

    void PlayAudioFun()
    {
        audioClear[2].Play();
    }


}
