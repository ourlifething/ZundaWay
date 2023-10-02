using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WalkX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(new Vector3(-10f, 0, 0), 20f)
    .SetEase(Ease.OutSine);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
