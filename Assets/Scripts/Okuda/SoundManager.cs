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

        // 落下音再生タイミング
        Invoke("PlayAudioAfterDelay", 0.8f);

        //タイトルコール開始
        Invoke("VoiceTitleCall", 2.8f);

        // ゲーム説明音声開始
        Invoke("VoiceGameDescription", 5.2f);

    }
    //落下音
    void PlayAudioAfterDelay()
    {
        audioStart[2].Play();
    }
    //タイトルコール
    void VoiceTitleCall()
    {
        audioStart[3].Play();
    }
    //ゲームの説明
    void VoiceGameDescription()
    {
        audioStart[1].Play();
    }
}
