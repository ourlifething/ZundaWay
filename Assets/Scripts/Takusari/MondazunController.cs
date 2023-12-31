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
    private Sequence sequence3;
    private SpriteRenderer spriteRender;
    public Sprite clearSprite;
    private Animator anim;
    
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        audioLevel1 = GetComponents<AudioSource>();
        sequence = DOTween.Sequence()
        .Append(transform.DOScale(new Vector3(0.1f,0.4f,0.2f),0.5f))
        .Append(transform.DOScale(new Vector3(0.2f,0.2f,0.2f),0.5f))
            .Pause()
            .SetAutoKill(false); 
        
        sequence2 = DOTween.Sequence()
        //.Append(transform.DOShakePosition(1f,5f,30,1,false,false))
        .Append(transform.DOShakeRotation(1f,180f,90,90,true))
        .Append(spriteRender.DOColor(new Color(0,0,0),1.5f))
        .Append(transform.DORotate(new Vector3(0,0,-90),2))
            .Pause()
            .SetAutoKill(false);

        sequence3 = DOTween.Sequence()
        .Append(transform.DOShakeRotation(1f, 90f, 60, 90, true))
        .Append(spriteRender.DOColor(Color.gray,1.0f))
        .Append(transform.DORotate(new Vector3(0,0,90),1.0f))
            .Pause()
            .SetAutoKill(false); 
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
        }
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

    public  void SpriteChange()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        spriteRender.sprite = clearSprite;
        Debug.Log("o");
    }

    public void normaDame()
    {
        this.GetComponent<Animator>().enabled = false;
        sequence3.Play();
    }

}
