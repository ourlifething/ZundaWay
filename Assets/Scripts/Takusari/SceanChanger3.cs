using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceanChanger3 : MonoBehaviour
{
    public GameObject Makuhiki;
    private SpriteRenderer spriteRenderer;
   // public Canvas canvas;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Makuhiki, new Vector3(0,0,0), Quaternion.identity);

            Invoke("SceanChange", 4.0f);
            Invoke("WhiteOut",2.0f);
        }
    }
    void SceanChange()
    {
        SceneManager.LoadScene("Start");
    }

    void WhiteOut()
    {
        spriteRenderer.DOFade(1.0f,3.0f);
        //canvas.enabled = false;
    }
}
