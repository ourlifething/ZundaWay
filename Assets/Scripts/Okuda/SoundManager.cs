using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour

{
    AudioSource[] audioStart;
    //スタートボタンがクリックされている状態かどうか
    private bool StartButtonClicked = false;
    //遊び方ボタンがクリックされている状態かどうか
    private bool AsobikataButtonClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        audioStart = GetComponents<AudioSource>();
        audioStart[0].Play();

        // 落下音再生タイミング
        Invoke("PlayAudioAfterDelay", 0.8f);

        //タイトルコール開始
        if(StartButtonClicked == false && AsobikataButtonClicked == false)
        {
            Invoke("VoiceTitleCall", 2.8f);
        }
        

        // ゲーム説明音声開始
        if (StartButtonClicked == false && AsobikataButtonClicked == false)
        {
            Invoke("VoiceGameDescription", 5.2f);
        }
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
        AsobikataButtonClicked = true;
        audioStart[4].Play();
        //クリックされたらゲーム説明を中止
        audioStart[1].Pause();
        //クリックされたらタイトルコールを中止
        audioStart[3].Pause();

        // 遊び方ボタンがクリックされたら、ゲームの説明 or タイトルコールをキャンセル
        CancelInvoke("VoiceGameDescription");
        CancelInvoke("VoiceTitleCall");
    }
    //スタートボタンがクリックされたら
    public void OnClickStart()
    {
        StartButtonClicked = true;
        audioStart[5].Play();
        //クリックされたらゲーム説明を中止
        audioStart[1].Pause();
        //クリックされたらタイトルコールを中止
        audioStart[3].Pause();

        // スタートボタンがクリックされたら、ゲームの説明 or タイトルコールをキャンセル
        CancelInvoke("VoiceGameDescription");
        CancelInvoke("VoiceTitleCall");
    }
}
