using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiritanControllerR : MonoBehaviour
{
    float runSpeed;
    public float speed;
    void Start()
    {
        
    }
    void Update()
    {
        this.runSpeed = -0.01f + speed * Time.deltaTime;
        transform.Translate(runSpeed,0,0);
        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}
