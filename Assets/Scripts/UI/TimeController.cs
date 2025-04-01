using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    // 経過時間をfloatで保持する（例：1.5秒など小数も扱える）
    //floatは「小数点ありの数（実数）」を表すデータ型。　0fのように数字＋fの数が入るよ
    private float elapsedTime = 0f;

    // タイマーが動いているかを判定（trueで進行中、falseで停止）
    //boolはtrueかfalseしか入らないデータ型　今回のオンオフ判定の用途にはぴったり
    private bool isRunning = true;

    void Update()
    {
        // タイマーが止まっているなら何もしない
        //! は「not（?ではない）」という意味。　　=!isRunning は「isRunningがfalseだったら」という意味
        if (!isRunning) return;

        // 前のフレームからの時間を加算
        //Time.deltaTime は「前のフレームからの経過時間（秒）」を表す便利なやつ。Unity側の機能
        elapsedTime += Time.deltaTime;

        // 経過時間を「○時間○分○秒」に変換
        // Mathf：Unityが用意した「数学関数」の集まり
        //FloorToInt() 小数点以下を切り捨てて、整数に変換する関数
        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // 表示を更新
        timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    // タイマーを止める用の関数（外部から呼べる）
    public void StopTimer()
    {
        isRunning = false;
    }

    // タイマーをリセットして再スタートする関数
    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }
}