using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public GameObject GhostPrefabL;
    public GameObject GhostPrefabR;
    public GameObject GhostPrefabF;
    public float genSpeed;
    bool steerActive = false;
    AudioSource[] audioLevel3;

    void Start()
    {
        audioLevel3 = GetComponents<AudioSource>();

    }

    public void geneStart()
    {
        InvokeRepeating("GenGhost", 1, genSpeed);
    }
    public void geneStop()
    {
        CancelInvoke();
    }

    void Update()
    {
        
    }
    void GenGhost()
    {
        int genInt = Random.Range(0,3);
        if (genInt == 0)
        {
            Instantiate(GhostPrefabL, new Vector3(-8, Random.Range(-3.5f,4.5f), 0), Quaternion.identity);
            Debug.Log("Left");
            audioLevel3[0].Play();
        }
        if (genInt == 1)
        {
            Instantiate(GhostPrefabR, new Vector3(8, Random.Range(-3.5f,4.5f), 0), Quaternion.identity);
            Debug.Log("Right");
            audioLevel3[0].Play();
        }
        if(genInt == 2)
        {
            Instantiate(GhostPrefabF, new Vector3(-2.5f + 4 * Random.value, 10, 0),Quaternion.identity);
            Debug.Log("Front");
            audioLevel3[0].Play();
        }
    }
}
