using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public MondazunController mondazun;
    public LifePanel lifePanel;

    void Update()
    {
        lifePanel.UpdateLife(mondazun.Life());
        if (mondazun.Life() <= 0)
        {
            Debug.Log("バカなぁぁぁぁぁ");
            enabled = false;
            //Invoke("FalledMiss",2.0f);
        }
    }
    void FalledMiss()
    {
        SceneManager.LoadScene("Miss");
    }
}
