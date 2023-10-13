using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceanChanger3 : MonoBehaviour
{
    public GameObject Makuhiki;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Makuhiki, new Vector3(0,0,0), Quaternion.identity);

            SceanChange();
        }
    }
    void SceanChange()
    {
        SceneManager.LoadScene("Start");
    }
}
