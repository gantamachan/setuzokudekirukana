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

            AudioManager.Instance.PlaySE("cardopen");

            //card�𗠕Ԃ��������˗�
            nameRevealer.RevealCell(input);
            progressText.text = $"{answerTracker.Count} / {totalCount}";

            //�X�N���[��
            var cell = nameRevealer.GetAllCells().FirstOrDefault(c => c.CellName == input);
            if (cell != null)
            {
                scrollController.ScrollToCell(cell);
            }

            if (answerTracker.Count == totalCount)
            {
                resultText.text = "�Q�[���N���A�I";
                timerController.StopTimer();

                nameRevealer.ClearHighlight();
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

    public void GiveUp()
    {
        timerController.StopTimer(); // �^�C�}�[��~

        //�c���擾
        int remaining = totalCount - answerTracker.Count;
        resultText.text = $"�M�u�A�b�v�F�c��{remaining}��";

        AudioManager.Instance.PlaySE("end");

        answerButton.SetActive(false);

        nameRevealer.ClearHighlight();

        // �S�J�[�h���擾
        var allCells = nameRevealer.GetAllCells(); // CorrectNameGridSpawner������

        foreach (var cell in nameRevealer.GetAllCells())
        {
           

            if (answerTracker.IsAnswered(cell.CellName))
            {
                // ���������J�[�h�͂ӂ��ɊJ��
                cell.Reveal();
            }
            else
            {
                // ���񓚂̃J�[�h�͐Ԃ��\��
                cell.RevealAsMissed(); 
            }
        }

        // �E ���͗������b�N����i�����������Ȃ��j
        inputField.interactable = false;

        inputField.interactable = false; // ���͕s��
    }
}