using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHowToPlay : MonoBehaviour
{
    AudioSource[] audioHowToPlayVoice;
    // Start is called before the first frame update
    void Start()
    {
        audioHowToPlayVoice = GetComponents<AudioSource>();
        Invoke("PlayAudioHowToPlayVoice", 1.0f);

    }

    void PlayAudioHowToPlayVoice()
    {
        audioHowToPlayVoice[0].Play();
    }
}
