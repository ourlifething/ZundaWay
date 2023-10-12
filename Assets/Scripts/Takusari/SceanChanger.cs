using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanChanger : MonoBehaviour
{
    public float changeTime;
    void Start()
    {
        Invoke("SceanChange",changeTime);
    }

    void Update()
    {
        
    }
    void SceanChange()
    {
        SceneManager.LoadScene("Level2");
    }
}
