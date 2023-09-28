using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZundaGenerator : MonoBehaviour
{
    public GameObject zundaPrefab;
    public float genSpeed;
    bool steerActive = false;
    void Start()
    {
        InvokeRepeating("GenZunda", 1, genSpeed);
    }
    
    public void SetSteerActive(bool steerActive)
    {
        if (steerActive == false){
            this.steerActive = false;
        }
        if (steerActive == true){
            this.steerActive = true;
        }
    }

    void Update() {
        
    }
    void GenZunda(){
        Instantiate(zundaPrefab,new Vector3(-2.5f + 5 * Random.value,6,0),Quaternion.identity);
    }
}
