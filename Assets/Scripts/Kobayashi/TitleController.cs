using System.Collections;
using UnityEngine;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;

public class TitleController : MonoBehaviour
{
    AudioSource[] audioTitle;

    // Start is called before the first frame update
    void Start()
    {
        audioTitle = GetComponents<AudioSource>();
        // 落下音再生タイミング
        Invoke("PlayAudioAfterDelay", 0.8f);

        //落下アニメーション
        transform.DOLocalMove(new Vector3(-0.03f, 2.63f, 0f), 2.5f)
            .SetEase(Ease.InOutElastic)
            .OnComplete(() =>
            {
                 audioTitle[1].Play();
            });     
    }
    void PlayAudioAfterDelay()
    {
        audioTitle[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
