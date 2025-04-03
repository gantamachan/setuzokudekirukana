using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollController : MonoBehaviour
{
    //スクロールを取得　
    //ScrollRect scrollRect：UnityのUIでスクロールを制御するクラス
    [SerializeField] private ScrollRect scrollRect;

    private Coroutine scrollCoroutine;

    //? ターゲットセルとは？？？
    public void ScrollToCell(CorrectNameCell targetCell)
    {


        //RectTransform：UIの位置・サイズを管理するための型（TransformのUI版）
        //　ターゲットセルの位置情報を取得
        RectTransform target = targetCell.GetComponent<RectTransform>();
        //スクロール範囲全体を取得
        RectTransform content = scrollRect.content;
        //実際のスクロールを取得
        RectTransform viewport = scrollRect.viewport;


        //画面内の高さを確認
        float viewportHeight = viewport.rect.height;
        //中身全体の高さを取得？
        float contentHeight = content.rect.height;
        //ターゲットセルのローカル座標を取得（Y軸のみ動かしたいので、Yだけ）　
        //Mathf.Abs() 絶対値で取得？
        float cellLocalY = Mathf.Abs(target.localPosition.y);

        //ここで高さ調整できるよ
        float offset = viewportHeight * 0.3f; // 中央よりちょっと上を意図する　
                                              // Mathf.Clamp01()：値が0以下や1以上にならないよう制限
        float normalizedPos = Mathf.Clamp01(1f - (cellLocalY - offset) / (contentHeight - viewportHeight));


        // 今動いてるアニメがあったら止める！
        if (scrollCoroutine != null)
        {
            StopCoroutine(scrollCoroutine);
        }


        //実際にスクロールをする関数（Unityのありがたい機能）
        scrollCoroutine = StartCoroutine(SmoothScrollTo(normalizedPos, 0.3f));

    }


    //IEnumerator 時間をかけて処理する関数の戻り値の型?
    //targetPos：最終的にスクロールしたい位置（0〜1）で指定
    //duration：アニメーションにかける時間（秒）
    private IEnumerator SmoothScrollTo(float targetPos, float duration)
    {
        //現在のスクロール位置
        float startPos = scrollRect.verticalNormalizedPosition;
        float elapsed = 0f;

        //アニメーション再生中は繰り返す
        while (elapsed < duration)
        {
            //elapsed 前のフレームからの経過時間（秒)
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration); // 0～1の間で割合を計算
            float newPos = Mathf.Lerp(startPos, targetPos, t); // スムーズに補間
            scrollRect.verticalNormalizedPosition = newPos;
            yield return null; // 次のフレームまで待つ（=1フレームごとに動かす）
        }

        // 最後にピッタリ合わせる（誤差防止）
        scrollRect.verticalNormalizedPosition = targetPos;
    }
}

