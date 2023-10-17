using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using DG.Tweening;

public class GameControllerLevel3 : MonoBehaviour
{
    enum State
    {
        Ready,
        Play,
        GameOver,
        Clear
    }

    State state;
    public ScrollScript sS;
    public MondazunController mondazun;
    public ZundaGenerator generator;
    public ZundaGenerator ankoGene;
    public KiritanGenerator kiriGene;
    public GhostGenerator ghostGene;
    public UIController ucon;
    public ScoreController scon;

    public int normaScore;
    public Text normaText;
    public float count;
    public Text countText;
    public Text startText;
    public Text gameOverText;
    public RectTransform image;
    public Image popup;
    public Image zunda;
    public Image popupMini;
    public GameObject clearEdamame;
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
                Destroy(normaText);

                startText.text = "Start!";
                
                Destroy(normaText);
                count -= Time.deltaTime;
                countText.text = "あと" + count.ToString("f1") + "秒";
                if (mondazun.Miss() || (count <= 0 && ucon.getScore() < normaScore)) 
                GameOver();
                if (count <= 0 && ucon.getScore() >= normaScore)
                    Clear();
                break;
            case State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space)) Reload();
                break;
            case State.Clear:
            if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Clear");
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
        
        image.DOScale(new Vector3(5,4,4),1f);
        image.DOPunchPosition(new Vector3(0,2,0),1f);            
        zunda.DOFade(1,4f);

        normaText.DOText("    x "+normaScore.ToString() + "\n\n60秒...以内に集めよう！\n\nPress SpaceKey!",4f);

        mondazun.SetSteerActive(false);
        generator.geneStop();
        ankoGene.geneStop();
        ghostGene.geneStop();
        sS.OnOfChange(true);
    }

    void GameStart()
    {
        state = State.Play;
        zunda.gameObject.SetActive(false);
        popup.DOFade(0,0.5f);
        popupMini.DOFade(1,0.1f);
        startText.gameObject.SetActive(true);
        startText.DOFade(1,0.1f);
        Invoke("FalText",1);

        mondazun.SetSteerActive(true);
        generator.geneStart();
        ankoGene.geneStart();
        kiriGene.geneStart();
        ghostGene.geneStart();
    }
    void GameOver()
    {
        state = State.GameOver;
        int thisScore = ucon.getScore();
        if (mondazun.Miss())
        {
            gameOverText.text = "ゲームオーバー...\nPress SpaceKey!";
        }
        if (count <= 0 && thisScore < normaScore)
        {
            gameOverText.text = "ノルマ未達成...\nあと" + (normaScore - thisScore) + "個\nPress SpaceKey!";
            mondazun.normaDame();
        }

        popupMini.DOFade(1,0.1f);
        gameOverText.gameObject.SetActive(true);

        mondazun.SetSteerActive(false);
        generator.geneStop();
        ankoGene.geneStop();
        kiriGene.geneStop();
        ghostGene.geneStop();
        sS.OnOfChange(false);
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
        ScoreController.score3=ucon.getScore();
        ScoreController.scoreTotal+=ScoreController.score3;
        scon.ScoreTotal();
    }
    void Clear()
    {
        state = State.Clear;
        gameOverText.text = "クリア!\nPress SpaceKey!";
        popupMini.DOFade(1,0.1f);
        gameOverText.gameObject.SetActive(true);
        mondazun.SpriteChange();

        Instantiate(clearEdamame, new Vector3(0,0,0), Quaternion.identity);
        mondazun.SetSteerActive(false);
        generator.geneStop();
        ankoGene.geneStop();
        kiriGene.geneStop();
        ghostGene.geneStop();
        sS.OnOfChange(false);
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
        ScoreController.score3=ucon.getScore();
        ScoreController.scoreTotal+=ScoreController.score3;

    }
    void Reload()
    {
        gameOverText.gameObject.SetActive(false);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        ScoreController.scoreTotal-=ScoreController.score3;
        ScoreController.score3=0;
    }
    void FalText(){
        startText.gameObject.SetActive(false);
        popupMini.DOFade(0,0.1F);
    }
}
