using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WalkMondazun : MonoBehaviour
{
    private Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence()
        .Append(transform.DOMoveX(1,2.2f))
        .Append(transform.DOScaleY(0.4f,0.5f))
        .Append(transform.DOScaleY(0.2f,0.5f))
        .Append(transform.DOShakePosition(6f,1f,30,30,false,false));

        sequence.Play();
    }

    void Update()
    {
        
    }
}
