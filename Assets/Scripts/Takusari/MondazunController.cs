using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MondazunController : MonoBehaviour
{
    public float speed;
    float xLimit = 2.5f;
    float yLimit = 5f;
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

        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -xLimit, xLimit);
        currentPos.y = Mathf.Clamp(currentPos.y, -yLimit, yLimit);

        transform.position = currentPos;
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
            life--;
            Destroy(coll.gameObject);
            Debug.Log("ぐえー");
        }
    }

}
