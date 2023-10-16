using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class SoundTransition2 : MonoBehaviour
{
    AudioSource[] audioTransition2;
    // Start is called before the first frame update
    void Start()
    {
        audioTransition2 = GetComponents<AudioSource>();
        Invoke("PlayAudioGhost", 2.0f);

    }
    //Ç´ÇËÇΩÇÒÇÃçUåÇâπ
    void PlayAudioGhost()
    {
        audioTransition2[1].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
