using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIFadeOut : MonoBehaviour
{
    public Image imageToFade; // フェードアウトさせるイメージ
    private bool isFading = false;

    // ボタンを押したときに呼び出されるメソッド
    public void OnButtonClick()
    {
        if (!isFading)
        {
            isFading = true;
            imageToFade.DOFade(1.0f, 0.3f).OnComplete(FadeOutComplete);
            //Debug.Log("ok");
        }
    }

    private void FadeOutComplete()
    {
        isFading = false;
        // フェードアウト完了時の処理をここに追加
        SceneManager.LoadScene("Level1"); 
    }
}
