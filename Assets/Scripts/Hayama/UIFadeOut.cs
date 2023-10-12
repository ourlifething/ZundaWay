using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
            // フェードアウトのアニメーションを設定
            imageToFade.DOFade(0f, 1.0f).OnComplete(FadeOutComplete);
        }
    }

    private void FadeOutComplete()
    {
        isFading = false;
        // フェードアウト完了時の処理をここに追加
    }
}
