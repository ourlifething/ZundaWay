using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WalkX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(-10, 10f)
    .SetEase(Ease.OutSine);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
