using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControllerR : MonoBehaviour
{
    float runSpeed;
    public float speed;
    private Vector3 targetpos;
    void Start()
    {
        targetpos = transform.position;
    }
    void Update()
    {
        this.runSpeed = 0.01f + speed * Time.deltaTime;
        targetpos.x -= runSpeed;
        transform.position = new Vector3(targetpos.x, Mathf.Sin(Time.time) * 1.2f + targetpos.y, targetpos.z);
        if(transform.position.x <= -5.5)
        {
            Destroy(gameObject);
        }
    }
}
