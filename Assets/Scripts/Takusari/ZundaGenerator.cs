using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZundaGenerator : MonoBehaviour
{
    public GameObject zundaPrefab;
    public float genSpeed;
    void Start()
    {
        InvokeRepeating("GenZunda", 1, genSpeed);
    }

    void GenZunda(){
        Instantiate(zundaPrefab,new Vector3(-2.5f + 5 * Random.value,6,0),Quaternion.identity);
    }
}
