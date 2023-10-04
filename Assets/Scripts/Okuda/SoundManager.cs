using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour

{
    AudioSource audioStart;
    // Start is called before the first frame update
    void Start()
    {
        audioStart = GetComponent<AudioSource>();
        audioStart.Play();
        //フェードアウト
        float fadeOutStartTime = 98f;
        audioStart.DOFade(0, 2).SetDelay(fadeOutStartTime);
        //フェードアウト完了後にループ再生
        float loopStartTime = 100f;
        float loopLength = audioStart.clip.length - loopStartTime;

        DOTween.Sequence()
            .SetDelay(loopStartTime)
            .AppendCallback(() => audioStart.PlayScheduled(AudioSettings.dspTime + 0.1))
            .AppendInterval(loopLength)
            .SetLoops(-1);
    }
}
