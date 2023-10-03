using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    int score = 0;
    GameObject scoreText;
    AudioSource[] audioLevel1_canvas;
    public int getScore()
    {
        return this.score;
    }

    public void AddScore()
    {
        this.score += 1;
        //�l���������񂾂�4�̔{���̎��ɂ���voice����
        if(this.score % 4 == 0)
        {
            audioLevel1_canvas[0].Play();
        }
        
    }
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
        audioLevel1_canvas = GetComponents<AudioSource>();
    }
    void Update()
    {
        scoreText.GetComponent<Text> ().text = ": " + score.ToString("D");
    }
}
