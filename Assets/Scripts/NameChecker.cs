using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMesh���g���Ƃ��͂Ƃ肠�����������
using System.Linq;


public class NameChecker : MonoBehaviour
{
    //Inspector��Ō�����悤�ɂ�������@�O����A�N�Z�X�ł��Ȃ���@TMPro���p�ӂ��Ă�ϐ��̌^�@�ϐ��i������₷�����R�ɒ�`�j
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text answeredText;
    [SerializeField] private TMP_Text resultText;

    [SerializeField] private TMP_Text progressText;

    //HashSet(�d�����Ȃ����X�g���쐬�j�@������^����@�ϐ��i���R�j�@���@�V���������Hashset�����Ƃ�������
    private HashSet<string> answeredNames = new HashSet<string>();
    //List���쐬
    private List<CorrectNameCell> allCells = new List<CorrectNameCell>();

    private List<string> correctNames;


    private int correctCount = 0;
    private int totalCount = 0;


    void Start()
    {
       //���X�g��ǂݍ���
        List<GodFieldData> dataList = GodFieldDataLoader.Load();
        //���O���������o��
        correctNames = dataList.Select(d => d.Name).ToList();

        //correctNames�̃J�E���g�����S�ẴJ�[�h�̖���
        totalCount = correctNames.Count;

        progressText.text = $"{correctCount} / {totalCount}";
    }



    private void Update()
    {
        // �G���^�[�L�[�iReturn�j�����������`�F�b�N
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckInputName(); // �{�^���Ɠ����֐������s�I
        }

    }




    // �߂�l�̂Ȃ��֐��@���R�Ɋ֐������`�@Unity���̑���Ń{�^������������Ăяo�����悤�ɂ���B
    public void CheckInputName()
    {
        //�ϐ��̌^�i�����񂾂�I���ĈӖ��j�@�ϐ��i���R�j�ϐ��B���Ő錾�����ϐ��ƈ�v������@������Ƃ��ēǂދ@�\�@�󔒂������֗��@�\
        string input = inputField.text.Trim();
        
        //�����@string�^�̊֐��ł���input������ۂ������Ȃ���΁@�����
        if (string.IsNullOrEmpty(input))
        {
            resultText.text = "�󗓂ł�";
            EndCheck();
            return;
        }

        //�����@input�̒��g�����X�g�Ɂ@���݂�����@�����`
        if (answeredNames.Contains(input))
        {
            resultText.text = "���ɉ񓚍ς�";
            EndCheck();
            return;
            
        }

        //Contains ���݂��邩�ǂ����m���߂�
        //�����@input�̒��g�����O�ɗp�ӂ������X�g�ɑ��݂�����@
        if(correctNames.Contains(input))
        {
            resultText.text = "����";
            //FindObjectOfType	�V�[�����̃X�N���v�g��T���֗��֐�
            var spawner = FindObjectOfType<CorrectNameGridSpawner>();

            // Hashset�ɂ��̖��O��ǉ�
            answeredNames.Add(input);

            //corectCount��1�ǉ�
            correctCount++;

            progressText.text = $"{correctCount} / {totalCount}";

            foreach (CorrectNameCell cell in spawner.GetAllCells())
            {
                if (cell.CellName == input)
                {
                    cell.Reveal();
                    break;
                }
            }



            EndCheck();

            
        }
        else
        {
            resultText.text = "�s����";
        }


        if (correctCount == totalCount)
        {
            resultText.text = "�Q�[���N���A�I";
        }

    }


    private void EndCheck()
    {
        inputField.text = "";
    }


    

}