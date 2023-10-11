using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float scrollSpeed;
    public float startPosition;
    public float endPotision;
    public bool onof;

    void Update()
    {
        if (onof == true)
        {
            transform.Translate(0, -1 * scrollSpeed * Time.deltaTime, 0);
            if (transform.position.y <= endPotision) ScrollEnd();
        }
    }
    void ScrollEnd()
    {
        float diff = transform.position.y - endPotision;
        Vector3 restatPotision = transform.position;
        restatPotision.y = startPosition + diff;
        transform.position = restatPotision;

        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
    public void OnOfChange(bool onof)
    {
        if (onof == true)
        {
            this.onof = true;
            Debug.Log("true");
        }
        if (onof == false)
        {
            this.onof = false;
            Debug.Log("false");
        }
    }
}
