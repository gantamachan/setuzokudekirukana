using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//メインコントローラー
public class NameCheckerV2 : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text answeredText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private TimerController timerController;

    [SerializeField] private GameObject answerButton;


    private NameValidator nameValidator;
    private AnswerTracker answerTracker;
    private CorrectNameRevealer nameRevealer;
    private ScrollController scrollController;

    private int totalCount;

    private void Start()
    {
        var dataList = GodFieldDataLoader.Load();
        var correctNames = dataList.Select(d => d.Name).ToList();
        totalCount = correctNames.Count;

        nameValidator = new NameValidator(correctNames);
        answerTracker = new AnswerTracker();
        nameRevealer = new CorrectNameRevealer(FindObjectOfType<CorrectNameGridSpawner>());

        progressText.text = $"0 / {totalCount}";

        scrollController = FindObjectOfType<ScrollController>();
    }

    private void Update()
    {
        //Enterキーで関数を起動
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckInputName();
        }
    }

    public void CheckInputName()
    {
        string input = inputField.text.Trim();

        if (string.IsNullOrEmpty(input))
        {
            resultText.text = "空欄です";
            EndCheck();
            return;
        }

        //answerTrackerからすでに正解しているかを受け取る
        if (answerTracker.IsAnswered(input))
        {
            resultText.text = $"既に回答済み　：　{input}";
            EndCheck();
            return;
        }

        //nameValidatorから入力された内容が正しいか確認
        if (nameValidator.IsCorrect(input))
        {
            resultText.text = $"正解　：　{input}";
            //Hashリストに追加
            answerTracker.AddAnswer(input);

            AudioManager.Instance.PlaySE("cardopen");

            //cardを裏返す処理を依頼
            nameRevealer.RevealCell(input);
            progressText.text = $"{answerTracker.Count} / {totalCount}";

            //スクロール
            var cell = nameRevealer.GetAllCells().FirstOrDefault(c => c.CellName == input);
            if (cell != null)
            {
                scrollController.ScrollToCell(cell);
            }

            if (answerTracker.Count == totalCount)
            {
                resultText.text = "ゲームクリア！";
                timerController.StopTimer();

                nameRevealer.ClearHighlight();
            }

            EndCheck();
        }
        else
        {
            resultText.text = "不正解";
            inputField.Select();
            inputField.ActivateInputField();
            inputField.caretPosition = inputField.text.Length;
        }
    }

    private void EndCheck()
    {
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void GiveUp()
    {
        timerController.StopTimer(); // タイマー停止

        //残数取得
        int remaining = totalCount - answerTracker.Count;
        resultText.text = $"ギブアップ：残り{remaining}個";

        AudioManager.Instance.PlaySE("end");

        answerButton.SetActive(false);

        nameRevealer.ClearHighlight();

        // 全カードを取得
        var allCells = nameRevealer.GetAllCells(); // CorrectNameGridSpawnerから取る

        foreach (var cell in nameRevealer.GetAllCells())
        {
           

            if (answerTracker.IsAnswered(cell.CellName))
            {
                // 正解したカードはふつうに開く
                cell.Reveal();
            }
            else
            {
                // 未回答のカードは赤く表示
                cell.RevealAsMissed(); 
            }
        }

        // ⑥ 入力欄をロックする（もう答えられない）
        inputField.interactable = false;

        inputField.interactable = false; // 入力不可に
    }
}