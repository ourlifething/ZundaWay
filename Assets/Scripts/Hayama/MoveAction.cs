using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoveAction : MonoBehaviour
{
    void Start()
    {
        transform.DOLocalMove(new Vector3(0, 0.2f, 0), 4f)
        .SetEase(Ease.InOutCubic)
        .SetLoops(-1, LoopType.Yoyo);
    }
}