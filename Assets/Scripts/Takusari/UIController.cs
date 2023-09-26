using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    int score = 0;
    GameObject scoreText;

    public void AddScore()
    {
        this.score += 1;
    }
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }
    void Update()
    {
        scoreText.GetComponent<Text> ().text = ":" + score.ToString("D");
    }
}
