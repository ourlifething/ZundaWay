using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClearController : MonoBehaviour
{
    public Image logo;
    public Image logoBack;
    public ScoreController scon;

    // Start is called before the first frame update
    void Start()
    {
        logo.DOFade(1,2f)
        .SetDelay(2f);
        logoBack.DOFade(1,2f)
        .SetDelay(2f);

        scon.ScoreTotal();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
