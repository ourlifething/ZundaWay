using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoveAction1 : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalMove(new Vector3(-1f, 0, 0), 5f)
        .SetEase(Ease.InOutSine)
        .SetLoops(-1, LoopType.Yoyo);
    }
}