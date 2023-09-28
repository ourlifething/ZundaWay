using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int normaScore;
    void Start()
    {
        Ready();
    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetKeyDown(KeyCode.Space)) GameStart();
                break;
            case State.Play:
                if (mondazun.Miss()) GameOver();
                break;
            case State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space)) Reload();
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
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
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
