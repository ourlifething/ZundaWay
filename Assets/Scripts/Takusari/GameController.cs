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
        generator.SetSteerActive(false);
        Debug.Log("Ready");
    }

    void GameStart()
    {
        Debug.Log("Start");
        state = State.Play;

        mondazun.SetSteerActive(true);
        generator.SetSteerActive(true);
    }
    void GameOver()
    {
        state = State.GameOver;

        mondazun.SetSteerActive(false);
        generator.SetSteerActive(false);
    }
    void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
