using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanChanger2 : MonoBehaviour
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
        SceneManager.LoadScene("Level3");
    }
}
