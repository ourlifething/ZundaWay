using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControllerF : MonoBehaviour
{
    float runSpeed;
    public float speed;
    private Vector3 targetpos;
    void Start()
    {
        targetpos = transform.position;
    }
    void FixedUpdate()
    {
        this.runSpeed = 0.01f + speed * Time.deltaTime;
        targetpos.y -= runSpeed;
        transform.position = new Vector3(Mathf.Sin(Time.time) * 1.0f + targetpos.x, targetpos.y, targetpos.z);
        if(transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
