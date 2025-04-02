using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//���C���R���g���[���[
public class NameCheckerV2 : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text answeredText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private TimerController timerController;
    

    private NameValidator nameValidator;
    private AnswerTracker answerTracker;
    private CorrectNameRevealer nameRevealer;

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
    }

    private void Update()
    {
        //Enter�L�[�Ŋ֐����N��
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
            resultText.text = "�󗓂ł�";
            EndCheck();
            return;
        }

        //answerTracker���炷�łɐ������Ă��邩���󂯎��
        if (answerTracker.IsAnswered(input))
        {
            resultText.text = $"���ɉ񓚍ς݁@�F�@{input}";
            EndCheck();
            return;
        }

        //nameValidator������͂��ꂽ���e�����������m�F
        if (nameValidator.IsCorrect(input))
        {
            resultText.text = $"�����@�F�@{input}";
            //Hash���X�g�ɒǉ�
            answerTracker.AddAnswer(input);
            //card�𗠕Ԃ��������˗�
            nameRevealer.RevealCell(input);
            progressText.text = $"{answerTracker.Count} / {totalCount}";

            if (answerTracker.Count == totalCount)
            {
                resultText.text = "�Q�[���N���A�I";
                timerController.StopTimer();
            }

            EndCheck();
        }
        else
        {
            resultText.text = "�s����";
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
}