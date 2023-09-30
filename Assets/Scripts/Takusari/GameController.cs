using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    public MondazunController mondazun;
    public ZundaGenerator generator;
    public ZundaGenerator ankoGene;
    public UIController ucon;

    public int normaScore;
    public Text normaText;
    public float count;
    public Text countText;
    public Text startText;
    public Text gameOverText;
    void Start()
    {
        Ready();
        gameOverText.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetKeyDown(KeyCode.Space)) GameStart();
                break;
            case State.Play:
                startText.text = "Start!";
                Invoke(nameof(DesText),1f);
                Destroy(normaText);
                count -= Time.deltaTime;
                countText.text = "あと" + count.ToString("f1") + "m";
                if (mondazun.Miss() || count <= 0) GameOver();
                break;
            case State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space)) Reload();
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
        normaText.text = normaScore.ToString() + "個集めよう！";

        mondazun.SetSteerActive(false);
        generator.geneStop();
        ankoGene.geneStop();
    }

    void GameStart()
    {
        state = State.Play;

        mondazun.SetSteerActive(true);
        generator.geneStart();
        ankoGene.geneStart();
    }
    void GameOver()
    {
        state = State.GameOver;
        int thisScore = ucon.getScore();
        if (mondazun.Miss())
        {
            gameOverText.text = "ゲームオーバー...";
        }
        if (count <= 0 && thisScore < normaScore)
        {
            gameOverText.text = "ノルマ未達成...\nあと" + (normaScore - thisScore) + "個";
        }
        if (count <= 0 && thisScore >= normaScore)
        {
            gameOverText.text = "クリア!";
        }
        gameOverText.gameObject.SetActive(true);

        mondazun.SetSteerActive(false);
        generator.geneStop();
        ankoGene.geneStop();
        GameObject[] tagObj1 = GameObject.FindGameObjectsWithTag("Zunda");
        foreach (GameObject obj in tagObj1)
        {
            Destroy(obj);
        }
        GameObject[] tagObj2 = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in tagObj2)
        {
            Destroy(obj);
        }
    }
    void Reload()
    {
        gameOverText.gameObject.SetActive(false);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    void DesText()
    {
        startText.gameObject.SetActive(false);
    }
}
