using System.Collections;
using TMPro;
using UnityEngine;

public class HowTo : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _initialDelay = 2f; // シーン立ち上げ後の初期待機時間
    [SerializeField] private float _lineDelay = 0.5f; // 行間の待機時間
    [SerializeField] private float _delayDuration = 0.1f; // 文字を表示する間隔

    private string[] _texts;
    private int currentIndex = 0;

    private bool isTyping = false;

    void Start()
    {
        _texts = new string[]
        {
            "x1ステージごとに目標の個数を時間内に集めよう",
            "",
            "",
            "",
            "",
            "",
            "体力が０にならないように気を付けて進もう",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "ずんだ以外にぶつかると体力枝豆が減るよ、お化けにあたると数秒動けなくなるから注意"
        };

        // シーン起動後の初期待機時間後に文字表示を開始
        StartCoroutine(StartTypingAfterDelay());

        // 行間隔を設定（ピクセル単位で指定）
        _text.lineSpacing = 10f; // 例として 10 ピクセルに設定
    }

    IEnumerator StartTypingAfterDelay()
    {
        yield return new WaitForSeconds(_initialDelay);

        for (int i = 0; i < _texts.Length; i++)
        {
            string textToDisplay = _texts[i];

            if (i > 0)
            {
                _text.text += "\n"; // 改行を追加（最初の行以外）
            }

            int textLength = textToDisplay.Length;

            for (int j = 0; j < textLength; j++)
            {
                _text.text += textToDisplay[j];
                yield return new WaitForSeconds(_delayDuration);
            }

            currentIndex++;

            // 最後の行でなければ指定の待機時間を置く
            if (i < _texts.Length - 1)
            {
                yield return new WaitForSeconds(_lineDelay);
            }
        }
    }
}
