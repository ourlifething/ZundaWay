using System.Collections;
using UnityEngine;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;

public class TitleController : MonoBehaviour
{ 

    // Start is called before the first frame update
     void Start()
    {
        transform.DOLocalMove(new Vector3(-0.03f, 2.63f, 0f), 3f)
        .SetEase(Ease.InOutElastic);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
