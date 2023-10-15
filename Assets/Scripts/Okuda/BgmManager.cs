using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class BgmManager : MonoBehaviour
{
    //スタートからHowToPlayへの画面遷移はBGMが変わらずなり続ける仕様
    public static BgmManager instance;//static 変数でBgmManager型のインスタンスを保持
    void Awake()
    {
        //初回のAwakeの時のみここがtrueになりインスタンスが登録される
        if (instance == null)
        {
            instance = this;//このインスタンスをstatic な instanceに登録
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);//２回目以降重複して作成してしまったgameObjectを削除
        }
    }
    

    // Update is called once per frame
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
       
    }
    // HowToPlay以外のシーンに遷移した場合はBGMを停止
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "HowToPlay")
        {
            Destroy(gameObject);
        }
    }
}
