using System.Collections;
using UnityEngine;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;

public class TitleController : MonoBehaviour
{
    public GameObject logo;
    public GameObject logoBack;
    // Start is called before the first frame update
    void Start()
    {
        logo.transform.DOLocalMove(new Vector3(-0.03f, 2.63f, 0f), 2.5f)
            .SetEase(Ease.InOutElastic);     
        logoBack.transform.DOLocalMove(new Vector3(-0.13f, 2.53f, 0f), 2.5f);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
