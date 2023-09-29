using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MondazunController : MonoBehaviour
{
    public float speed;
    bool steerActive = false;
    public bool SteerActive()
    {
        return steerActive;
    }
    bool miss;
    public bool Miss()
    {
        return miss;
    }
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
            Debug.Log("う、うめえ");
        }
        if (coll.gameObject.tag == "Enemy")
        {
            life--;
            Destroy(coll.gameObject);
            Debug.Log("ぐえー");
        }
        if (life <= 0)
        {
            Debug.Log("バカなぁぁぁぁぁ");
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

}
