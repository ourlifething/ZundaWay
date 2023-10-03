using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiritanGenerator : MonoBehaviour
{
    public GameObject KiritanPrefabL;
    public GameObject KiritanPrefabR;
    public float genSpeed;
    bool steerActive = false;
    AudioSource[] audioLevel2;

    void Start()
    {
        audioLevel2 = GetComponents<AudioSource>();

    }

    public void geneStart()
    {
        InvokeRepeating("GenKiritan", 1, genSpeed);
        Debug.Log("OK");
    }
    public void geneStop()
    {
        CancelInvoke();
    }

    void Update()
    {
        
    }
    void GenKiritan()
    {
        int genInt = Random.Range(0,2);
        if (genInt == 0)
        {
            Instantiate(KiritanPrefabL, new Vector3(-6, Random.Range(-4.5f,5.5f), 0), Quaternion.identity);
            audioLevel2[0].Play();
        }
        if (genInt > 0)
        {
            Instantiate(KiritanPrefabR, new Vector3(6, Random.Range(-4.5f,5.5f), 0), Quaternion.identity);
            Debug.Log("Gene");
            audioLevel2[0].Play();
        }
    }
}
