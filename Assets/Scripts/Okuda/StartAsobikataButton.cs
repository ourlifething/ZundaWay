using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class StartAsobikataButton : MonoBehaviour
{
    AudioSource[] audioStartVoice;
    //サウンドオブジェクト取得用
    public GameObject SMObject;
    void Start()
    {
        audioStartVoice = GetComponents<AudioSource>();
    }
    public void OnClickAsobikata()
    {
        audioStartVoice[0].Play();
        //クリックされたらゲーム説明を中止
        AudioSource[] pauseAudio = SMObject.GetComponents<AudioSource>();
        pauseAudio[1].Pause();
    }
    public void OnClickStart()
    {
        audioStartVoice[0].Play();
        //クリックされたらゲーム説明を中止
        AudioSource[] pauseAudio = SMObject.GetComponents<AudioSource>();
        pauseAudio[1].Pause();
    }
    
}
