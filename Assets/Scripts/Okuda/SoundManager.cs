using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour

{
    AudioSource[] audioStart;
    // Start is called before the first frame update
    void Start()
    {
        audioStart = GetComponents<AudioSource>();
        audioStart[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
