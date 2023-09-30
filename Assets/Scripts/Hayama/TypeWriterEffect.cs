using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delayDuration = 0.1f;

    private Coroutine _showCoroutine;
    private int currentIndex = 0;
    private string[] _texts;

    void Start()
    {
        _text.maxVisibleCharacters = 0;
        _texts = new string[]
        {
            "xxxxxxxxxxxxxxxxx",
            "xxxxxxxxxxxxxxxxx",
            "VOICEVOX:ずんだもん"
        };
    }

    public void Show()
    {
        if (_showCoroutine != null && currentIndex < 3){
            StopCoroutine(_showCoroutine);
        }
        if(currentIndex < 3){
            _showCoroutine = StartCoroutine(ShowCoroutine(currentIndex)); // コルーチンに現在の文章のインデックスを渡す
        }
    }

    private IEnumerator ShowCoroutine(int textIndex)
    {

        if (textIndex < _texts.Length)
        {
            _text.text = _texts[textIndex];
            currentIndex++;
        }
        else
        {
            yield break;
        }

        var delay = new WaitForSeconds(_delayDuration);
        var length = _text.text.Length;

        for (var i = 0; i < length; i++)
        {
            _text.maxVisibleCharacters = i;
            yield return delay;
        }

        _text.maxVisibleCharacters = length;

        _showCoroutine = null;
    }
}
