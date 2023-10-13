using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextScript2 : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        text.DOText("Next Stage...Level3", 3).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
