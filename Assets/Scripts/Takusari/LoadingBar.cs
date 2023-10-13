using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        //image.SetActive(true);
        image.DOFillAmount(1f,4.9f).SetEase(Ease.InQuart);
    }

    void Update()
    {
        
    }
}
