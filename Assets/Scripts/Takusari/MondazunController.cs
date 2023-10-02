using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MondazunController : MonoBehaviour
{
    public float speed;
    bool steerActive = false;
    AudioSource[] damageSe;

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
        damageSe = GetComponents<AudioSource>();

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
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Instantiate(ExplosionEffect,coll.gameObject.transform.position,Quaternion.identity);
            life--;
            Destroy(coll.gameObject);
            damageSe[0].Play();
            damageSe[1].Play();
        }
        if (coll.gameObject.tag == "Ghost")
        {
            Debug.Log("Stun");
            steerActive = false;
            Destroy(coll.gameObject);
            Invoke("Recover", 1.0f);
        }
        if (life <= 0)
        {
            enabled = false;
            miss = true;
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
