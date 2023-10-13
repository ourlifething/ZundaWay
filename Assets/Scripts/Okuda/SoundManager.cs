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
    //遊び方ボタンがクリックされたら
    public void OnClickAsobikata()
    {
        audioStart[4].Play();
        //クリックされたらゲーム説明を中止
        audioStart[1].Pause();
        //クリックされたらタイトルコールを中止
        audioStart[3].Pause();
    }
    //スタートボタンがクリックされたら
    public void OnClickStart()
    {
        audioStart[5].Play();
        //クリックされたらゲーム説明を中止
        audioStart[1].Pause();
        //クリックされたらタイトルコールを中止
        audioStart[3].Pause();
    }
}
