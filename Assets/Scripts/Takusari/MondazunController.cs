using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MondazunController : MonoBehaviour
{
    public float speed;
    const int DefaultLife = 3;
    int life = DefaultLife;
    public int Life()
    {
        return life;
    }
    void Start()
    {
        
    }

    void Update()
    {
        //矢印キーで移動
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * speed;
    }

    //接触した際の処理
    void OnTriggerEnter2D(Collider2D coll) {
        GameObject.Find("Canvas").GetComponent<UIController> ().AddScore();

        Destroy(coll.gameObject);
    }
    void OnTriggerEnter2D(){
        life --;
        Destroy(gameObject);
    }

}
