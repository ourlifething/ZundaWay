using UnityEngine;

public class GameObjectDisplayController : MonoBehaviour
{
    public GameObject objectToShow;
    public float displayDelay = 2.0f; // 表示までの待機時間（秒）

    private float timer;
    private bool isDisplayed;

    private void Start()
    {
        // 初期化
        timer = 0.0f;
        isDisplayed = false;
        objectToShow.SetActive(false); // ゲーム開始時にオブジェクトを非表示にする
    }

    private void Update()
    {
        if (!isDisplayed)
        {
            timer += Time.deltaTime; // 経過時間をカウント

            if (timer >= displayDelay)
            {
                // 一定時間経過したらオブジェクトを表示
                objectToShow.SetActive(true);
                isDisplayed = true;
            }
        }
    }
}
