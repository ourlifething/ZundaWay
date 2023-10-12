using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ScoreController : MonoBehaviour
{
    public static int score1;
    public static int score2;
    public static int score3;
    public static int scoreTotal;
    

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

            GetComponent<Text>().text="総合獲得ずんだ数は...\n"+scoreTotal+"個!\n\n総合順位は"+ranking.rank+"位です!";
        }
    }
    

}
[Serializable]
class RankingData{
    public int lastId;
    public int rank;
}
