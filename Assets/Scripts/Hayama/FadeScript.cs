using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image _image;
    // Start is called before the first frame update
    void Start()
    {
        Fade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fade(){
        _image.DOFade(0.4f, 1f)
        .SetLoops(-1, LoopType.Yoyo); // Yoyoで逆再生し続ける
    }
}
