using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KiritanScript : MonoBehaviour
{
    public GameObject kiritanpo;
    void Start()
    {
        transform.DOLocalMoveX(2.5f,2.5f).SetEase(Ease.OutSine);
        GetComponent<Animator>().enabled = false;
        Invoke("Shoot",3.0f);
    }

    void Update()
    { 
    }
    void Shoot()
    {
        Instantiate(kiritanpo,this.transform.position,Quaternion.identity);
    }
}
