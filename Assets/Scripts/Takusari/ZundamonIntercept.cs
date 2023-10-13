using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZundamonIntercept : MonoBehaviour
{
    private Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence()
        .Append(this.transform.DOJump(new Vector3(0f, -1f, 0f), jumpPower: 4f, numJumps: 1, duration: 3f))
        //.Append(transform.DOMoveY(-1,2f))
        .Append(transform.DOScale(new Vector3(0.075f,0.075f,0.075f),1f)).SetEase(Ease.OutQuart);

        sequence.Play();
    }

    void Update()
    {
        
    }
}
