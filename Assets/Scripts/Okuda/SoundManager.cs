using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Reporting;

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

        //遊び方ボタンの音声の長さを取得
        float howToPlaytButtonSoundLength = audioStart[4].clip.length;

        // 音声再生の終了を待ってから画面遷移
        StartCoroutine(LoadHowToPlayAfterSoundLength(howToPlaytButtonSoundLength));

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

        // スタートボタンの音声の長さを取得
        float startButtonSoundLength = audioStart[5].clip.length;

        // 音声再生の終了を待ってから画面遷移
        StartCoroutine(LoadLevel1AfterSoundLength(startButtonSoundLength));

        //クリックされたらゲーム説明を中止
        audioStart[1].Pause();
        //クリックされたらタイトルコールを中止
        audioStart[3].Pause();

        // スタートボタンがクリックされたら、ゲームの説明 or タイトルコールをキャンセル
        CancelInvoke("VoiceGameDescription");
        CancelInvoke("VoiceTitleCall");
    }
    IEnumerator LoadHowToPlayAfterSoundLength(float soundLength)
    {
        yield return new WaitForSeconds(soundLength);
        SceneManager.LoadScene("HowToPlay");
    }

    IEnumerator LoadLevel1AfterSoundLength(float soundLength)
    {
        yield return new WaitForSeconds(soundLength);
        SceneManager.LoadScene("Level1");
    }
}
