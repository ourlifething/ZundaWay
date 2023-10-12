using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using DG.Tweening;

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
    }
    IEnumerator PostConnect(){
        WWWForm form=new WWWForm();
        form.AddField("score",scoreTotal);
        Debug.Log(scoreTotal);
        string url="http://localhost:8080/ScoreAPI/GetRanking";
        UnityWebRequest uwr=UnityWebRequest.Post(url,form);
        Debug.Log(form);
        yield return uwr.SendWebRequest();
        if(uwr.isNetworkError){
            Debug.Log(uwr.error);
        }else{
            var ranking=JsonUtility.FromJson<RankingData>(uwr.downloadHandler.text);
            Debug.Log(ranking.lastId+":"+ranking.rank);
            Debug.Log(ranking.rankIn);

            rank=ranking.rank;
            id=ranking.lastId;
            rankIn=ranking.rankIn;
            Debug.Log(rank+" "+id+" "+rankIn);

            Invoke(nameof(Popup),3f);


            
        }
    }
    
    public void Popup(){
            image.DOFade(1,1f);
            popup.DOScale(new Vector3(3,3,3),1f);
            popup.DOPunchPosition(new Vector3(0,2,0),1f); 
            
            text.DOText("総合獲得ずんだ餅は...\n"+scoreTotal+"個!\nランキングは"+rank+"位\n上位"+Math.Round(rankIn/id*100)+"%の実力です!",4f);

    }

}
[Serializable]
class RankingData{
    public int lastId;
    public int rank;
    public int rankIn;
}
