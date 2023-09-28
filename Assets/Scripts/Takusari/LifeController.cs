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
        
    }
    
}
