using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZundaController : MonoBehaviour
{
    float fallspeed;
    public float speed;
    void Start()
    {
        this.fallspeed = 0.01f + speed * Time.deltaTime;
    }
    void Update()
    {
        transform.Translate(0, -fallspeed, 0);
        
        if (transform.position.y < -5.5f){
            Destroy (gameObject);
        }
    }
}
