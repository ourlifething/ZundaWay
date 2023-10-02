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
    void Start()
    {

    }

    public void geneStart()
    {
        InvokeRepeating("GenGhost", 1, genSpeed);
        Debug.Log("OK");
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
        }
        if (genInt == 1)
        {
            Instantiate(GhostPrefabR, new Vector3(8, Random.Range(-3.5f,4.5f), 0), Quaternion.identity);
            Debug.Log("Right");
        }
        if(genInt == 2)
        {
            Instantiate(GhostPrefabF, new Vector3(-2.5f + 4 * Random.value, 10, 0),Quaternion.identity);
            Debug.Log("Front");
        }
    }
}
