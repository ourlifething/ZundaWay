using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MondazunController : MonoBehaviour
{
    public float speed;
    bool steerActive = false;
    AudioSource[] audioLevel1;
    public GameObject gameOvarEffect;

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
    private Sequence sequence;
    private Sequence sequence2;
    private SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioLevel1 = GetComponents<AudioSource>();
        sequence = DOTween.Sequence()
        .Append(transform.DOScaleY(0.4f,0.5f))
        .Append(transform.DOScaleY(0.2f,0.5f))
            .Pause()
            .SetAutoKill(false); 
        
        sequence2 = DOTween.Sequence()
        //.Append(transform.DOShakePosition(1f,5f,30,1,false,false))
        .Append(transform.DOShakeRotation(1f,180f,90,90,true))
        .Append(sprite.DOColor(new Color(0,0,0),1.5f))
        .Append(transform.DORotate(new Vector3(0,0,-90),2))
            .Pause()
            .SetAutoKill(false);

        //SpriteRenderer = GetComponent<SpriteRenderer>();
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
            sequence.Restart();
            audioLevel1[4].Play();
            Invoke("Recover", 1.0f);
            
        }
        if (life <= 0)
        {
            enabled = false;
            miss = true;
            audioLevel1[3].Play();
            this.GetComponent<Animator>().enabled = false;
            FinalExplosion();
            sequence2.Play();
            //SpriteRenderer.color = new Color32(80,80,80,255);
            

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
        steerActive = true;
        transform.DOKill();
        return;
    }
    void FinalExplosion()
    {
        Transform transform = this.transform;
        Instantiate(gameOvarEffect, transform.position, Quaternion.identity);
    }

}
