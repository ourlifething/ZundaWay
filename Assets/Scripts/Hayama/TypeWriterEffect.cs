using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    // 対象のテキスト
    [SerializeField] private TMP_Text _text;
    
    // 次の文字を表示するまでの時間[s]
    [SerializeField] private float _delayDuration = 0.1f;

    private Coroutine _showCoroutine;
    private int currentIndex = 0; // 現在の文章のインデックス
    private string[] _texts; // 異なる文章を格納する配列

    // Startメソッドで文章の初期化を行う
    void Start()
    {
        // ゲーム開始時にテキストを非表示にする
        _text.maxVisibleCharacters = 0;

        // 表示する文章の配列を初期化
        _texts = new string[]
        {
            "このゲームは、すんだもんが東北ずん子の元へずんだ餅を届けるために奮闘するゲームです。降りかかる試練を避けて、たくさんのずんだ餅を獲得しましょう。",
            "xxxxxxxxxxxxxxxxx",
            "VOICEVOX:ずんだもん"
        };
    }

    public void Show()
    {
        // 前回の演出処理が走っていたら、停止
        if (_showCoroutine != null)
            StopCoroutine(_showCoroutine);

        // １文字ずつ表示する演出のコルーチンを実行する
        _showCoroutine = StartCoroutine(ShowCoroutine());
    }

    // １文字ずつ表示する演出のコルーチン
    private IEnumerator ShowCoroutine()
    {
        // 待機用コルーチン
        // GC Allocを最小化するためキャッシュしておく
        var delay = new WaitForSeconds(_delayDuration);

        // 現在の文章を設定
        if (currentIndex < _texts.Length)
        {
            _text.text = _texts[currentIndex];
            currentIndex++;
        }
        else
        {
            // 表示する文章がない場合はコルーチンを終了
            yield break;
        }

        // テキスト全体の長さ
        var length = _text.text.Length;
        
        // １文字ずつ表示する演出
        for (var i = 0; i < length; i++)
        {
            // 徐々に表示文字数を増やしていく
            _text.maxVisibleCharacters = i;
            
            // 一定時間待機
            yield return delay;
        }

        // 演出が終わったら全ての文字を表示する
        _text.maxVisibleCharacters = length;

        _showCoroutine = null;
    }

    public void OnButtonClick()
    {
        // ボタンがクリックされたらテキストを表示する
        Show();
    }
}
