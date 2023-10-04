using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MondazunController : MonoBehaviour
{
    public float speed;
    bool steerActive = false;
    AudioSource[] audioLevel1;

    public bool SteerActive()
    {
        return steerActive;
    }
    bool miss;
    public bool Miss()
    {
        return miss;
    }
    const float stunCount = 1.0f;
    public float amountVal = 0;
    float recoverTime = 0.0f;
    float xLimit = 2.5f;
    float yLimit = 5f;
    const int DefaultLife = 3;
    int life = DefaultLife;
    public int Life()
    {
        return life;
    }
    public GameObject ExplosionEffect;
    void Start()
    {
        audioLevel1 = GetComponents<AudioSource>();
    }

    public void SetSteerActive(bool steerActive)
    {
        if (steerActive == false)
        {
            this.steerActive = false;
        }
        if (steerActive == true)
        {
            this.steerActive = true;
        }
    }
    void Update()
    {
        if (steerActive == true)
        {
            //矢印キーで移動
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            transform.position += new Vector3(x, y, 0) * Time.deltaTime * speed;

            Vector3 currentPos = transform.position;
            currentPos.x = Mathf.Clamp(currentPos.x, -xLimit, xLimit);
            currentPos.y = Mathf.Clamp(currentPos.y, -yLimit, yLimit);

            transform.position = currentPos;
        }
    }

    //接触した際の処理
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Zunda")
        {
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

            Destroy(coll.gameObject);
            audioLevel1[2].Play();
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Instantiate(ExplosionEffect, coll.gameObject.transform.position, Quaternion.identity);
            life--;
            Destroy(coll.gameObject);
            audioLevel1[0].Play();
            audioLevel1[1].Play();
        }
        if (coll.gameObject.tag == "Ghost")
        {
            Debug.Log("Stun");
            steerActive = false;
            Destroy(coll.gameObject);
            Invoke("Recover", 1.0f);
            transform.DOScaleY(0.5f,0.5f)
            .SetLoops(2,LoopType.Yoyo);
        }
        if (life <= 0)
        {
            enabled = false;
            miss = true;
            audioLevel1[3].Play();

            //Invoke("FalledMiss",2.0f);
        }
        /*void FalledMiss()
        {
            SceneManager.LoadScene("Miss");
        }
        */


    }
    void Recover()
    {
        Debug.Log("Recover");
        steerActive = true;
        return;
    }

}
