using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ItakoController : MonoBehaviour
{
    private Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence()
        .Append(transform.DOMoveX(-1f,0.7f))
        .Append(transform.DORotate(new Vector3(0,180,0),0.3f))
        .Append(transform.DOMoveX(1f,0.7f))
        .Append(transform.DORotate(new Vector3(0,0,0),0.3f))
        .Append(transform.DOMoveX(-1f,0.7f))
        .Append(transform.DORotate(new Vector3(0,180,0),0.3f))
        .Append(transform.DOMoveX(1f,0.7f))
        .Append(transform.DORotate(new Vector3(0,0,0),0.3f))
        .Append(transform.DOMoveX(-1f,0.7f))
        .Append(transform.DORotate(new Vector3(0,180,0),0.3f))
        .Append(transform.DOMoveX(1f,0.7f))
        .Append(transform.DORotate(new Vector3(0,0,0),0.3f));
    }

    void Update()
    {
        sequence.Play();
    }

}
