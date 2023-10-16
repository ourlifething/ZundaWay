using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class ScoreController : MonoBehaviour
{
    public static int score1;
    public static int score2;
    public static int score3;
    public static int scoreTotal;
    public int rank;
    public float id;
    public float rankIn;
    public RectTransform popup;
    public Image image;
    public Text text;
    public float mathPerF;
    public int mathPer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreTotal(){
        StartCoroutine(PostConnect());
        Debug.Log("OK");
    }
    IEnumerator PostConnect(){
        WWWForm form=new WWWForm();
        form.AddField("score",scoreTotal);
        string url="http://localhost:8080/ScoreAPI/GetRanking";
        UnityWebRequest uwr=UnityWebRequest.Post(url,form);
        Debug.Log(form);
        yield return uwr.SendWebRequest();
        if(uwr.isNetworkError){
            Debug.Log(uwr.error);
        }else{
            var ranking=JsonUtility.FromJson<RankingData>(uwr.downloadHandler.text);

            rank=ranking.rank;
            id=ranking.lastId;
            rankIn=ranking.rankIn;


            string sName = SceneManager.GetActiveScene().name;
            if (sName == "Clear"){
                Invoke(nameof(PopupClear),2f);
            }else{
                Invoke(nameof(Popup),3f);
            }
        }
    }
    
    public void Popup(){
            image.DOFade(1,1f);
            popup.DOScale(new Vector3(4,4,4),1f);
            popup.DOPunchPosition(new Vector3(0,2,0),1f); 

            mathPerF=(rankIn/id)*100;
            mathPer=(int)mathPerF;
            if (mathPer==0)
            {
                mathPer=1;
            }
            text.DOText("総合獲得ずんだ餅は...\n"+scoreTotal+"個!\n総合ランキング..."+rank+"位\n\n上位"+mathPer+"%の実力です!",4f);

    }
    public void PopupClear(){
            image.DOFade(1,1f);

            mathPerF=(rankIn/id)*100;
            mathPer=(int)mathPerF;
            if (mathPer==0)
            {
                mathPer=1;
            }
            text.DOText("総合獲得ずんだ餅は...\nLevel1... "+score1+"\nLevel2... "+score2+"\nLevel3... "+score3+"\n\n合計は..."+scoreTotal+"個!\n総合ランキング..."+rank+"位\n上位"+mathPer+"%の実力です!\nPress SpaceKey!",5f);

            score1=0;
            score2=0;
            score3=0;
            scoreTotal=0;


    }

}
[Serializable]
class RankingData{
    public int lastId;
    public int rank;
    public int rankIn;
}
