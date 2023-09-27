using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public MondazunController mondazun;
    public LifePanel lifePanel;

    void Update()
    {
        lifePanel.UpdateLife(mondazun.Life());
    }
}
