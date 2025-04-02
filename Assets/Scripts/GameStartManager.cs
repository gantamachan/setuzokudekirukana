using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartManager : MonoBehaviour
{
    [SerializeField] private Button mainButton;
    [SerializeField] private TMP_InputField nameInputField;
    //タイマーコントローラーってscriptと接続
    [SerializeField] private TimerController timerController;
    [SerializeField] private TextMeshProUGUI buttonText;

    private bool isGameStarted = false;

    void Start()
    {
        // 初期状態：名前入力不可
        nameInputField.interactable = false;
        buttonText.text = "開始";
        mainButton.onClick.AddListener(OnMainButtonClicked);
    }

    private void OnMainButtonClicked()
    {
        if (!isGameStarted)
        {
            // ゲーム開始！
            isGameStarted = true;
           timerController.StartTimer();

            // 入力受付をONに
            nameInputField.interactable = true;
            nameInputField.text = "";
            nameInputField.ActivateInputField();

            // ボタンテキストを変更
            buttonText.text = "答える！";

            // ボタンの色を変えて分かりやすく（任意）
            mainButton.image.color = new Color(0.5f, 1f, 0.5f); // 薄い緑

            // NameCheckerなどに「開始済み」フラグを通知する場合はここで
        }
        else
        {
            // 回答送信処理へバイパス（例：NameChecker経由でCheckAnswer）
            FindObjectOfType<NameCheckerV2>().CheckInputName();
        }
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}