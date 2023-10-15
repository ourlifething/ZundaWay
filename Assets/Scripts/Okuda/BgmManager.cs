using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class BgmManager : MonoBehaviour
{
    AudioSource audioBgm;
    public bool DontDestroyEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);
        }
        audioBgm = GetComponent<AudioSource>();
        audioBgm.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
