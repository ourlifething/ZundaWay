using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float scrollSpeed;
    public float startPosition;
    public float endPotision;
    
    void Update()
    {
        transform.Translate(0, -1 * scrollSpeed * Time.deltaTime, 0);
        if(transform.position.y <= endPotision) ScrollEnd();
    }
    void ScrollEnd()
    {
        float diff = transform.position.y - endPotision;
        Vector3 restatPotision = transform.position;
        restatPotision.y = startPosition + diff;
        transform.position  = restatPotision;

        SendMessage("OnScrollEnd",SendMessageOptions.DontRequireReceiver);
    }
}
