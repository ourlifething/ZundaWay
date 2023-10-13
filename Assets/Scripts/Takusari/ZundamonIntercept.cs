using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZundamonIntercept : MonoBehaviour
{
    private Sequence sequence;
    public float scalex;
    public float scaley;
    public float scalez;
    public float transformx;
    void Start()
    {
        sequence = DOTween.Sequence()
        .Append(this.transform.DOJump(new Vector3(transformx, -1f, 0f), jumpPower: 4f, numJumps: 1, duration: 3f))
        //.Append(transform.DOMoveY(-1,2f))
        .Append(transform.DOScale(new Vector3(scalex,scaley,scalez),1f)).SetEase(Ease.OutQuart);

        sequence.Play();
    }

    void Update()
    {
        
    }
}
